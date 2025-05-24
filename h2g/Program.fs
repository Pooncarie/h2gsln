open h2glib
open System

[<EntryPoint>]
let main argv =

    let usage() =
        printfn "Usage: h2g.exe -w|-f|-s <input>"
        printfn "  -w: Get HTML from a web URL"
        printfn "  -f: Get HTML from a file"
        printfn "  -s: Get HTML from a string"
        Environment.Exit(1)

    if argv.Length < 2 || argv.Length > 2 || argv[0] = "-h" then 
        printfn "Invalid arguments."
        usage()

    if [ "-w"; "-f"; "-s" ] |> List.contains argv[0] |> not then
        printfn "Invalid option: %s" argv[0]
        usage()

    let result = match argv[0] with
                 | "-w" -> getFromWeb argv[1]
                 | "-f" -> getFromFile argv[1] 
                 | "-s" -> getFromString argv[1] 
                 | _ -> failwith "Invalid option"

    match result with
    | Ok actual -> printfn "%s" actual
    | Error e -> printfn "Error: %s" e

    0