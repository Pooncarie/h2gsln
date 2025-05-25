module h2glib

open System
open System.Text
open System.Linq
open HtmlAgilityPack


let private isSelfClosing (node: HtmlNode) =
    node.NodeType = HtmlNodeType.Element
    && not node.HasChildNodes
    && node.Closed
    && node.OuterHtml.TrimEnd().EndsWith("/>")

let private isVoidElement (node: HtmlNode) =
    match node.Name with
    | "area" | "base" | "br" | "col" | "embed" | "hr" | "img" | "input" 
    | "link" | "meta" | "param" | "source" | "track" | "wbr" -> true
    | _ -> isSelfClosing node

        
let private isFlagElement =  function
    | "async" | "autofocus" | "autoplay" | "checked" | "controls" 
    | "default" | "defer" | "disabled" | "hidden" 
    | "ismap" | "loop" | "multiple" | "muted" | "novalidate" 
    | "readonly"  | "required" | "reversed" 
    | "scope" | "selected"  -> true
    | _ -> false 

// e.g. data-bs-toggle => _dataBsToggle"
let private fixData (attr: HtmlAttribute) =
    let mutable bits = attr.Name.Split('-')
    if bits.Length > 1 then 
        bits <- bits |> Array.skip 1   
    else
        bits <- [| attr.Name |]

    let name = (("", bits) ||> Array.fold (
            fun acc x -> if acc = "" then acc + x else acc + "-" + x)) 
    $"_data \"{name}\" \"{attr.Value}\""

// e.g. aria-label => _ariaLabel
let private fixAria (attr: HtmlAttribute) =
    let bits = attr.Name.Split('-')
    if bits.Length < 2 then
        // If the attribute doesn't follow the expected pattern, return it as is
        $"_aria \"{attr.Name}\" \"{attr.Value}\""
    else
        // e.g. aria-activedescendant => _ariaActiveDescendant "value"
        match bits[1] with
        | "activedescendant" -> "_ariaActiveDescendant" + $" \"{attr.Value}\""
        | "autoComplete" -> "_ariaAutoComplete" + $" \"{attr.Value}\""
        | "colcount" -> "_ariaColCount" + $" \"{attr.Value}\""
        | "colindex" -> "_ariaColIndex" + $" \"{attr.Value}\""
        | "colspan" -> "_ariaColSpan" + $" \"{attr.Value}\""
        | "describedby" -> "_ariaDescribedBy" + $" \"{attr.Value}\""
        | "dropEffect" -> "_ariaDropEffect" + $" \"{attr.Value}\""
        | "errormessage" -> "_ariaErrorMessage" + $" \"{attr.Value}\""
        | "flowto" -> "_ariaFlowTo" + $" \"{attr.Value}\""
        | "haspopup" -> "_ariaHasPopup" + $" \"{attr.Value}\""
        | "keyshortcuts" -> "_ariaKeyShortcuts" + $" \"{attr.Value}\""
        | "labelledby" -> "_ariaLabelledBy" + $" \"{attr.Value}\""
        | "multiselectable" -> "_ariaMultiSelectable" + $" \"{attr.Value}\""
        | "posinset" -> "_ariaPosInSet" + $" \"{attr.Value}\""
        | "readonly" -> "_ariaReadOnly" + $" \"{attr.Value}\""
        | "roleDescription" -> "_ariaRoleDescription" + $" \"{attr.Value}\""
        | "rowcount" -> "_ariaRowCount" + $" \"{attr.Value}\""
        | "rowindex" -> "_ariaRowIndex" + $" \"{attr.Value}\""
        | "rowspan" -> "_ariaRowSpan" + $" \"{attr.Value}\""
        | "setsize" -> "_ariaSetSize" + $" \"{attr.Value}\""
        | "valuemax" -> "_ariaValueMax" + $" \"{attr.Value}\""
        | "valuemin" -> "_ariaValueMin" + $" \"{attr.Value}\""
        | "valuenow" -> "_ariaValueNow" + $" \"{attr.Value}\""
        | "valuetext" -> "_ariaValueText" + $" \"{attr.Value}\""
        | _ ->
        if String.IsNullOrWhiteSpace(attr.Value) || attr.Value.Length < 2 then
            ""
        else
            let name = "_" + bits[0] + string (Char.ToUpper(bits[1][0])) + bits[1].Substring(1);
            $"{name} \"{attr.Value}\""

// e.g. role="alertdialog" => _roleAlertDialog
let fixRole (attr: HtmlAttribute) =
    match attr.Value with
    | "alertdialog" -> "_roleAlertDialog" 
    | "checkbox" -> "_roleCheckBox" 
    | "columnheader" -> "_roleColumnHeader" 
    | "combobox" -> "_roleComboBox" 
    | "contentinfo" -> "_roleContentInfo"
    | "gridcell" -> "_roleGridCell" 
    | "listbox" -> "_roleListBox" 
    | "listitem" -> "_roleListItem"
    | "menubar" -> "_roleMenuBar" 
    | "menuitem" -> "_roleMenuItem" 
    | "menuitemcheckbox" -> "_roleMenuItemCheckBox" 
    | "menuitemradio" -> "_roleMenuItemRadio" 
    | "progressbar" -> "_roleProgressBar" 
    | "radiogroup" -> "_roleRadioGroup" 
    | "rowheader" -> "_roleRowHeader"
    | "searchbox" -> "_roleSearchBox" 
    | "spinbutton" -> "_roleSpinButton" 
    | "tablist" -> "_roleTabList" 
    | "tabpanel" -> "_roleTabPanel" 
    | "textbox" -> "_roleTextBox"
    | "toolbar" -> "_roleToolBar" 
    | "tooltip" -> "_roleToolTip" 
    | "treeitem" -> "_roleTreeItem" 
    | "treegrid" -> "_roleTreeGrid" 
    | _ ->
        if String.IsNullOrWhiteSpace(attr.Value) || attr.Value.Length < 2 then
            ""
        else
            let name = "_role" + string (Char.ToUpper(attr.Value[0])) + attr.Value.Substring(1);
            $"{name}"

let fixAttribute (attr: HtmlAttribute) =
    match attr.Name with
    | "http-equiv" -> "_httpEquiv" + $" \"{attr.Value}\""
    | "accept-charset" -> "_acceptCharset" + $" \"{attr.Value}\""
    | _ -> $"_{attr.Name} \"{attr.Value}\""
    

let private attributesToString  (attributes: HtmlAttributeCollection)  =
    let mutable attList = []
    
    if attributes.Count > 0 then
        for attr in attributes do
            let attrStr = 
                match attr.Name with
                | name when name.StartsWith("data-") -> fixData attr
                | name when name.StartsWith("aria-") -> fixAria attr
                | name when name = "role" -> fixRole attr
                | name when isFlagElement name -> $"_{attr.Name}"
                | _ -> fixAttribute attr
            attList <- attList @ [attrStr]
    attList

let private processAttributes(node: HtmlNode) =
    let attList = attributesToString node.Attributes
    if attList.Length > 0 then
        let joinedAtts =  ("", attList) ||> List.fold (fun acc x -> if acc = "" then acc + x else acc +  "; " + x)
        match node with
        | n when n.HasChildNodes -> $"[{joinedAtts}]  "
        | n when isVoidElement n -> $"[{joinedAtts}]\n"
        | _ -> $"[{joinedAtts}] []\n"
    else
        match node with
        | n when n.HasChildNodes -> "[] "
        | n when isVoidElement n -> "[]\n"
        | _ -> "[] []\n"

let rec private traverse (node: HtmlNode) (depth: int) (sb: StringBuilder)=
    if node.NodeType = HtmlNodeType.Element then
        if node.Name = "svg" then
            sb.Append($"{new string(' ', depth * 2)}rawText \"\"\"{node.OuterHtml}\"\"\";") |> ignore
        else
            sb.Append($"{new string(' ', depth * 2)}{node.Name} ") |> ignore
            sb.Append(processAttributes node) |> ignore

    if node.Name <> "svg" then
        if node.ChildNodes.Count > 0 then
            sb.Append("[\n") |> ignore
            for child in node.ChildNodes do
                traverse child (depth + 1) sb
            if node.NodeType = HtmlNodeType.Element then
                sb.Append($"{new string(' ', depth * 2)}]\n") |> ignore
        else
            if node.NodeType = HtmlNodeType.Text then
                if String.IsNullOrWhiteSpace(node.InnerText.Trim()) = false then
                    if node.ParentNode.Name = "script" then
                        sb.Append($"{new string(' ', depth * 2)}rawText \"\"\"{node.InnerText}\"\"\"\n") |> ignore
                    else
                        let trimmedText = node.InnerText.Trim().Replace("\"", "\\\"")
                        sb.Append($"{new string(' ', depth * 2)}str \"{trimmedText}\"\n") |> ignore
                    


let private parseHtml (htmlDoc: HtmlDocument) =
    if htmlDoc.ParseErrors.Count() > 0 then
        let errors = htmlDoc.ParseErrors |> Seq.map (fun e -> $"{e.Reason} at line {e.Line} column {e.LinePosition}")
        Error (String.Join("\n", errors))
    else
        let doc = htmlDoc.DocumentNode
        let sb = new StringBuilder()

        for child in doc.ChildNodes do
            traverse child 0 sb
        Ok (sb.ToString())

let getFromWeb (url: string) =
    match url with
    | _ when url.Trim() = "" -> Error "URL cannot be empty"
    | _ when not (url.StartsWith("http://") || url.StartsWith("https://")) -> Error "URL must start with http:// or https://"
    | _ ->
        try
            // Load the document to determine encoding       
            let encodingWeb = new HtmlWeb()
            let encodingDoc = encodingWeb.Load(url)
            let encoding = encodingDoc.Encoding

            // Load the document with the correct encoding
            let web = new HtmlWeb()
            web.OverrideEncoding <- encoding
            parseHtml (web.Load(url))
        with
        | :? System.Net.WebException as ex -> Error $"Web exception: {ex.Message}"
        | :? System.UriFormatException as ex -> Error $"URI format exception: {ex.Message}"
        | ex -> Error $"Unexpected exception: {ex.Message}"

let getFromFile (file: string) =
    match file with
    | _ when file.Trim() = "" -> Error "File path cannot be empty"
    | _ when not (System.IO.File.Exists(file)) -> Error "File does not exist"
    | _ ->
        try
            let doc = new HtmlDocument();
            doc.Load(file);
            parseHtml doc
        with
        | :? System.IO.FileNotFoundException as ex -> Error $"File not found: {ex.Message}"
        | :? System.UnauthorizedAccessException as ex -> Error $"Unauthorized access: {ex.Message}"
        | ex -> Error $"Unexpected exception: {ex.Message}"
        
let getFromString (html: string) =
    match html with
    | _ when html.Trim() = "" -> Error "HTML string cannot be empty"
    | _ ->
        let doc = new HtmlDocument();
        doc.LoadHtml(html);
        parseHtml doc
    

