open h2glib

[<EntryPoint>]
let main argv =
    let html2 = getFromWeb("http://www.wayneinnes.com")
    let html = getFromString"<div hx-post=\"mouse_entered\" hx-swap-oob=\"#alert\" hx-trigger=\"mouseenter\" checked id=\"1\"><b>[Here Mouse, Mouse]</b><hr/></div>"
    let html1 = getFromString "<body><div><hr>alalala</div><p></p><link rel=\"stylesheet\"><!-- a commnet --></body>"
    let html3 = getFromString "<div id=\"1\">Test</div>"
    let html4 = getFromString @"<form action=""dologin"" method=""post"">
                <div class=""mb-3 row has-validation"">
                    <label class=""form-label"" for=""email"">Email Address</label>
                    <div class=""col-sm-12"">
                        <input class=""form-control"" type=""text"" id=""email"" name=""email"" value="""">
                    </div>
                </div>
                <div class=""mb-3 row has-validation"">
                    <label class=""form-label"" for=""password"">Password</label>
                    <div class=""col-sm-12"">
                        <div class=""input-group"">
                            <input class=""form-control"" type=""password"" id=""password"" name=""password"" required>
                            <span class=""input-group-text bi-eye-slash"" id=""togglePassword-password"" style=""cursor: pointer""></span>
                        </div>
                    </div>
                </div>
                <div class=""m-1 row"">
                    <div></div>
                    <div>
                        <button type=""submit"" value=""login"" id=""btnSubmit"" class=""btn btn-primary m-2"">Login</button>
                    </div>
                </div>
            </form>"
    printfn "%s" (parseHtml html2)

    0 