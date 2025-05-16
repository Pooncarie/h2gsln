open h2glib

[<EntryPoint>]
let main argv =
    let html2 = getFromWeb("http://www.wayneinnes.com")
    let html = getFromString"<div hx-post=\"mouse_entered\" hx-swap-oob=\"#alert\" hx-trigger=\"mouseenter\" checked id=\"1\"><b>[Here Mouse, Mouse]</b><hr/></div>"
    let html1 = getFromString "<body><div><hr>alalala</div><p></p><link rel=\"stylesheet\"><!-- a commnet --></body>"
    let html3 = getFromString "<div>Test</div>"
    printfn "%s" (parseHtml html3)

    0 