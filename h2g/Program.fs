open h2glib
open System

[<EntryPoint>]
let main argv =

    if argv.Length < 2 then
        printfn "Usage: h2g.exe -w|-f|-s <input>"
        printfn "  -w: Get HTML from a web URL"
        printfn "  -f: Get HTML from a file"
        printfn "  -s: Get HTML from a string"
        1
    else
    let result = match argv[0] with
                 | "-w" -> getFromWeb argv[1]
                 | "-f" -> getFromFile argv[1] 
                 | "-s" -> getFromString argv[1] 
                 | _ -> Error "Invalid argument. Use 'w' for web, 'f' for file, or 's' for string."

    match result with
    | Ok actual -> printfn "%s" actual
    | Error e -> printfn "Error: %s" e

    0