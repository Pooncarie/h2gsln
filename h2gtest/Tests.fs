module h2gtest

open h2glib
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``parseHtml simple div with text`` () =
    let expected = "div [] [\n  str \"Test\"\n]\n"
    let html = getFromString "<div>Test</div>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``parseHtml nested elements`` () =
    let expected = "div [] [\n  span [] [\n    str \"Hello\"\n  ]\n]\n"
    let html = getFromString "<div><span>Hello</span></div>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``parseHtml with attributes`` () =
    let expected = "input [_checked; _type \"checkbox\"; _value \"1\"]\n"
    let html = getFromString "<input checked type=\"checkbox\" value=\"1\" />"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

[<Test>]
let ``parseHtml empty div`` () =
    let expected = "div [] []\n"
    let html = getFromString "<div></div>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
let ``parseHtml with data, aria, and hx attributes`` () =
    let expected = "div [_dataTest \"abc\"; _ariaLabel \"label\"; _hxPost \"/api\"] []\n"
    let html = getFromString "<div data-test=\"abc\" aria-label=\"label\" hx-post=\"/api\"></div>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
let ``parseHtml void element`` () =
    let expected = "br []\n"
    let html = getFromString "<br>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

[<Test>]
let ``parseHtml with comment`` () =
    let expected = "body [] [\n]\n"
    let html = getFromString "<body><!-- a comment --></body>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
// Test for role attribute
let ``parseHtml with role attribute`` () =
    let expected = "div [_role \"button\"] []\n"
    let html = getFromString "<div role=\"button\"></div>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for script tag
[<Test>]
let ``parseHtml with script tag`` () =
    let expected = "script [] [\n  str \"console.log('Hello World');\"\n]\n"
    let html = getFromString "<script>console.log('Hello World');</script>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// test for link tag
[<Test>]
let ``parseHtml with link tag`` () =
    let expected = "link [_rel \"stylesheet\"; _href \"style.css\"]\n"
    let html = getFromString "<link rel=\"stylesheet\" href=\"style.css\">"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for meta tag
[<Test>]
let ``parseHtml with meta tag`` () =
    let expected = "meta [_name \"viewport\"; _content \"width=device-width, initial-scale=1.0\"]\n"
    let html = getFromString "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for a tag
[<Test>]
let ``parseHtml with a tag`` () =
    let expected = "a [_href \"https://example.com\"]  [\n  str \"Click here\"\n]\n"
    let html = getFromString "<a href=\"https://example.com\">Click here</a>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for img tag
[<Test>]
let ``parseHtml with img tag`` () =
    let expected = "img [_src \"image.jpg\"; _alt \"An image\"]\n"
    let html = getFromString "<img src=\"image.jpg\" alt=\"An image\">"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for aria attributes
[<Test>]
let ``parseHtml with aria attributes`` () =
    let expected = "div [_ariaLabel \"label\"; _ariaHidden \"true\"] []\n"
    let html = getFromString "<div aria-label=\"label\" aria-hidden=\"true\"></div>"
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for empty html
[<Test>]
let ``parseHtml with empty html`` () =
    let expected = ""
    let html = getFromString ""
    let actual = 
        match parseHtml html with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for malformed html
[<Test>]
let ``parseHtml with malformed html`` () =
    let expected = "Start tag <div> was not found at line 1 column 6"
    let html = getFromString "<dixyz</div>"
    match parseHtml html with
    | Ok actual -> Assert.Fail $"Expected error but got: {actual}"
    | Error e -> Assert.That(e, Is.EqualTo(expected))
