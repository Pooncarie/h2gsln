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
    let actual = parseHtml html
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``parseHtml nested elements`` () =
    let expected = "div [] [\n  span [] [\n    str \"Hello\"\n  ]\n]\n"
    let html = getFromString "<div><span>Hello</span></div>"
    let actual = parseHtml html
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``parseHtml with attributes`` () =
    let expected = "input [_checked; _type \"checkbox\"; _value \"1\"]\n"
    let html = getFromString "<input checked type=\"checkbox\" value=\"1\" />"
    let actual = parseHtml html
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

[<Test>]
let ``parseHtml empty div`` () =
    let expected = "div [] []\n"
    let html = getFromString "<div></div>"
    let actual = parseHtml html
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
let ``parseHtml with data, aria, and hx attributes`` () =
    let expected = "div [_dataTest \"abc\"; _ariaLabel \"label\"; _hxPost \"/api\"] []\n"
    let html = getFromString "<div data-test=\"abc\" aria-label=\"label\" hx-post=\"/api\"></div>"
    let actual = parseHtml html
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
let ``parseHtml void element`` () =
    let expected = "br []\n"
    let html = getFromString "<br>"
    let actual = parseHtml html
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

[<Test>]
let ``parseHtml with comment`` () =
    let expected = "body [] [\n]\n"
    let html = getFromString "<body><!-- a comment --></body>"
    let actual = parseHtml html
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
// Test for role attribute
let ``parseHtml with role attribute`` () =
    let expected = "div [_role \"button\"] []\n"
    let html = getFromString "<div role=\"button\"></div>"
    let actual = parseHtml html
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))


