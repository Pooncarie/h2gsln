module h2glib

open System
open System.Text
open HtmlAgilityPack

let private isVoidElement (name: string) =
    match name with
    | "area" | "base" | "br" | "col" | "embed" | "hr" | "img" | "input" 
    | "link" | "meta" | "param" | "source" | "track" | "wbr" -> true
    | _ -> false

let private isFlagElement =  function
    | "async" | "autofocus" | "autoplay" | "checked" | "controls" 
    | "default" | "defer" | "disabled" | "hidden" 
    | "ismap" | "loop" | "multiple" | "muted" | "novalidate" 
    | "readonly"  | "required" | "reversed" 
    | "scope" | "selected"  -> true
    | _ -> false 

// e.g. data-bs-toggle => _dataBsToggle"
let private fixData (attr: HtmlAttribute) =
    let mutable bits = attr.Name.Split('-') |> Array.skip 1
    let name = "_data" +  (("", bits) ||> Array.fold (
            fun acc x -> acc + string (Char.ToUpper(x[0])) + x.Substring(1))) 
    $"{name} \"{attr.Value}\""

// e.g. aria-label => _ariaLabel
let private fixAria (attr: HtmlAttribute) =
    let bits = attr.Name.Split('-')
    let name = "_" + bits[0] + string (Char.ToUpper(bits[1][0])) + bits[1].Substring(1);
    $"{name} \"{attr.Value}\""

// e.g. hx-post => _hxPost
let private fixHtmx (attr: HtmlAttribute) =
    let bits = attr.Name.Split('-') |> Array.skip 1
    let name = "_hx" +  (("", bits) ||> 
        Array.fold (fun acc x -> acc + string (Char.ToUpper(x[0])) + x.Substring(1)))
    $"{name} \"{attr.Value}\""

let private attributesToString  (attributes: HtmlAttributeCollection)  =
    let mutable attList = []
    
    if attributes.Count > 0 then
        for attr in attributes do
            let attrStr = 
                match attr.Name with
                | name when name.StartsWith("data-") -> fixData attr
                | name when name.StartsWith("aria-") -> fixAria attr
                | name when name.StartsWith("hx-") -> fixHtmx attr
                | name when isFlagElement name -> $"_{attr.Name}"
                | _ -> $"_{attr.Name} \"{attr.Value}\""
            attList <- attList @ [attrStr]
    attList

let private processAttributes(node: HtmlNode) =
    let attList = attributesToString node.Attributes
    if attList.Length > 0 then
        let joinedAtts =  ("", attList) ||> List.fold (fun acc x -> if acc = "" then acc + x else acc +  "; " + x)
        match node with
        | n when n.HasChildNodes -> $"[{joinedAtts}]  "
        | n when isVoidElement n.Name -> $"[{joinedAtts}]\n"
        | _ -> $"[{joinedAtts}] []\n"
    else
        match node with
        | n when n.HasChildNodes -> "[] "
        | n when isVoidElement n.Name -> "[]\n"
        | _ -> "[] []\n"

let rec private traverse (node: HtmlNode) (depth: int) (sb: StringBuilder)=
    if node.NodeType = HtmlNodeType.Element then
        sb.Append($"{new string(' ', depth * 2)}{node.Name} ") |> ignore
        sb.Append(processAttributes node) |> ignore

    if node.ChildNodes.Count > 0 then
        sb.Append("[\n") |> ignore
        for child in node.ChildNodes do
            traverse child (depth + 1) sb
        if node.NodeType = HtmlNodeType.Element then
            sb.Append($"{new string(' ', depth * 2)}]\n") |> ignore
    else
        if node.NodeType = HtmlNodeType.Text then
            if String.IsNullOrWhiteSpace(node.InnerText.Trim()) = false then
                let trimmedText = node.InnerText.Trim().Replace("\"", "\\\"")
                sb.Append($"{new string(' ', depth * 2)}str \"{trimmedText}\"\n") |> ignore

let parseHtml (htmlDoc: HtmlDocument) =
    let doc = htmlDoc.DocumentNode
    let sb = new StringBuilder()

    for child in doc.ChildNodes do
        traverse child 0 sb
    sb.ToString()

let getFromWeb (url: string) =
    let web = new HtmlWeb();
    web.Load(url);

let getFromFile (file: string) =
    let doc = new HtmlDocument();
    doc.Load(file);
    doc

let getFromString (html: string) =
    let doc = new HtmlDocument();
    doc.LoadHtml(html);
    doc
    

