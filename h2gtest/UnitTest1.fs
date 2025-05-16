module h2gtest

open h2glib
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    let result =  "div [] []\n[\n  str \"Test\"\n]\n"
        
    let html3 = getFromString "<div>Test</div>"
    let parsedHtml = parseHtml html3
    Assert.That(result, Is.EqualTo(parsedHtml))
