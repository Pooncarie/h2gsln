module h2glib

open System
open System.Text
open HtmlAgilityPack

let isVoidElement (name: string) =
    match name with
    | "area" | "base" | "br" | "col" | "embed" | "hr" | "img" | "input" | "link" | "meta" | "param" | "source" | "track" | "wbr" -> true
    | _ -> false

let isFlagElement =  function
    | "async" | "autofocus" | "autoplay" | "checked" | "controls" | "default" | "defer" | "disabled" | "hidden" 
    | "ismap" | "loop" | "multiple" | "muted" | "novalidate" | "readonly"  | "required" | "reversed" 
    | "scope" | "selected"  -> true
    | _ -> false 

// e.g. data-bs-toggle => _dataBsToggle"
let fixData (attr: string) =
    let mutable bits = attr.Split('-') |> Array.skip 1
    "_data" +  (("", bits) ||> Array.fold (fun acc x -> acc + string (Char.ToUpper(x[0])) + x.Substring(1)))

// e.g. aria-label => _ariaLabel
let fixAria (attr: string) =
    let bits = attr.Split('-')
    "_" + bits[0] + string (Char.ToUpper(bits[1][0])) + bits[1].Substring(1);

// e.g. role => _role
let fixRole (attr: string) =
    "_role" + string (Char.ToUpper(attr[0])) + attr.Substring(1);

// e.g. hx-post => _hxPost
let fixHtmx (attr: string) =
    let bits = attr.Split('-') |> Array.skip 1
    "_hx" +  (("", bits) ||> Array.fold (fun acc x -> acc + string (Char.ToUpper(x[0])) + x.Substring(1)))

let processAttributes(node: HtmlNode) =
    let attributes = node.Attributes
    
    if attributes.Count > 0 then
        let mutable attList = []
        for attr in attributes do
            let attrStr = 
                match attr.Name with
                | name when name.StartsWith("data-") -> $"{fixData(attr.Name)} \"{attr.Value}\""
                | name when name.StartsWith("aria-") -> $"{fixAria(attr.Name)} \"{attr.Value}\""
                | name when name.StartsWith("hx-") -> $"{fixHtmx(attr.Name)} \"{attr.Value}\""
                | name when name = "role" -> $"{fixRole attr.Value}"
                | name when isFlagElement name -> $"_{attr.Name}"
                | _ -> $"_{attr.Name} \"{attr.Value}\""
            attList <- attList @ [attrStr]
    
        let joinedAtts =  ("", attList) ||> List.fold (fun acc x -> if acc = "" then acc + x else acc +  "; " + x)
        if node.HasChildNodes || isVoidElement node.Name then
            $"[{joinedAtts}]\n"
        else
            $"[{joinedAtts}] []\n"
    else
        if isVoidElement node.Name || node.HasChildNodes then
            "[]\n"
        else
            "[] []\n"

let rec traverse (node: HtmlNode) (depth: int) (sb: StringBuilder)=
    if node.NodeType = HtmlNodeType.Element then
        sb.Append($"{new string(' ', depth * 2)}{node.Name} ") |> ignore
        sb.Append(processAttributes node   ) |> ignore
    else 
        if node.NodeType = HtmlNodeType.Comment then
            sb.Append($"{new string(' ', depth * 2)}{node.InnerHtml.Trim()}\n") |> ignore

    if node.ChildNodes.Count > 0 then
        sb.Append($"{new string(' ', depth * 2)}[\n") |> ignore
        for child in node.ChildNodes do
            traverse child (depth + 1) sb
        if node.NodeType = HtmlNodeType.Element then
            sb.Append($"{new string(' ', depth * 2)}]\n") |> ignore
    else
        if node.NodeType = HtmlNodeType.Text then
            if String.IsNullOrWhiteSpace(node.InnerText.Trim()) = false then
                sb.Append($"{new string(' ', depth * 2)}str \"{node.InnerText.Trim()}\"\n") |> ignore

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
    

