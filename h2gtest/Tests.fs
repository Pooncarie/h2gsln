module h2gtest

open h2glib
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let ``getFromString simple div with text`` () =
    let expected = "div [] [\n  str \"Test\"\n]\n"
    let actual =
        match "<div>Test</div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual, Is.EqualTo expected)

[<Test>]
let ``getFromString nested elements`` () =
    let expected = "div [] [\n  span [] [\n    str \"Hello\"\n  ]\n]\n"
    let actual = 
        match "<div><span>Hello</span></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual, Is.EqualTo(expected))

[<Test>]
let ``getFromString with attributes`` () =
    let expected = "input [_checked; _type \"checkbox\"; _value \"1\"]\n"
    let actual = 
        match  "<input checked type=\"checkbox\" value=\"1\" />" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

[<Test>]
let ``getFromString empty div`` () =
    let expected = "div [] []\n"
    let actual = 
        match "<div></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
let ``getFromString with data, aria, and hx attributes`` () =
    let expected = "div [_data \"test\" \"abc\"; _ariaLabel \"label\"; _hx-post \"/api\"] []\n"
    let actual = 
        match "<div data-test=\"abc\" aria-label=\"label\" hx-post=\"/api\"></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test aria attributes
[<Test>]
let ``getFromString with aria attributes`` () =
    let expected = "div [_ariaLabel \"label\"; _ariaColSpan \"true\"] []\n"
    let actual = 
        match "<div aria-label=\"label\" aria-colspan=\"true\"></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
let ``getFromString void element`` () =
    let expected = "br []\n"
    let actual = 
        match "<br>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

[<Test>]
let ``getFromString with comment`` () =
    let expected = "body [] [\n  rawText \"\"\"<!-- a comment -->\"\"\";\n]\n"
    let actual = 
        match "<body><!-- a comment --></body>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for role attribute
[<Test>]
let ``getFromString with role attribute`` () =
    let expected = "div [_roleButton; _roleColumnHeader] []\n"
    let actual = 
        match "<div role=\"button\" role=\"columnheader\"></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for script tag
[<Test>]
let ``getFromString with script tag`` () =
    let expected = "script [] [\n  rawText \"\"\"console.log('ZZZZZZ');\"\"\"\n]\n"
    let actual = 
        match "<script>console.log('ZZZZZZ');</script>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// test for link tag
[<Test>]
let ``getFromString with link tag`` () =
    let expected = "link [_rel \"stylesheet\"; _href \"style.css\"]\n"
    let actual = 
        match "<link rel=\"stylesheet\" href=\"style.css\">" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for meta tag
[<Test>]
let ``getFromString with meta tag`` () =
    let expected = "meta [_name \"viewport\"; _content \"width=device-width, initial-scale=1.0\"]\n"
    let actual = 
        match "<meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for a tag
[<Test>]
let ``getFromString with a tag`` () =
    let expected = "a [_href \"https://example.com\"]  [\n  str \"Click here\"\n]\n"
    let actual = 
        match "<a href=\"https://example.com\">Click here</a>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for img tag
[<Test>]
let ``parseHtml with img tag`` () =
    let expected = "img [_src \"image.jpg\"; _alt \"An image\"]\n"
    let actual = 
        match "<img src=\"image.jpg\" alt=\"An image\">" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for aria attributes
[<Test>]
let ``getFromString with aria camel case attributes`` () =
    let expected = "div [_ariaLabel \"label\"; _ariaHidden \"true\"] []\n"
    let html = getFromString "<div aria-label=\"label\" aria-hidden=\"true\"></div>"
    let actual = 
        match "<div aria-label=\"label\" aria-hidden=\"true\"></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for malformed html
[<Test>]
let ``getFromString with malformed html`` () =
    let expected = "Start tag <div> was not found at line 1 column 6"
    let html = getFromString "<dixyz</div>"
    match "<dixyz</div>" |> getFromString with
    | Ok actual -> Assert.Fail $"Expected error but got: {actual}"
    | Error e -> Assert.That(e, Is.EqualTo(expected))

// Test for unclosed tag
[<Test>]
let ``getFromString with unclosed tag`` () =
    let expected = "div [] [\n  span [] []\n]\n"
    match "<div><span></div>" |> getFromString with
    | Ok actual -> Assert.That(actual, Is.EqualTo(expected))
    | Error e -> failwith e

// Test for empty html
[<Test>]
let ``getFromString with empty html`` () =
    let expected = "HTML string cannot be empty"
    match "" |> getFromString with
    | Ok s ->  Assert.Fail $"Expected error but got: {s}"
    | Error e ->  Assert.That(e, Is.EqualTo(expected))

// Test for empty html
[<Test>]
let ``getFromFile with empty html`` () =
    let expected = "File path cannot be empty"
    match "" |> getFromFile with
    | Ok s ->  Assert.Fail $"Expected error but got: {s}"
    | Error e ->  Assert.That(e, Is.EqualTo(expected))

// Test for file not found
[<Test>]
let ``getFromFile with file not found`` () =
    let expected = "File does not exist"
    match "non_existent_file.html" |> getFromFile with
    | Ok s ->  Assert.Fail $"Expected error but got: {s}"
    | Error e ->  Assert.That(e, Is.EqualTo(expected))

// Test getFromWeb with empty url
[<Test>]
let ``getFromWeb with empty url`` () =
    let expected = "URL cannot be empty"
    match getFromWeb "" with
    | Ok s ->  Assert.Fail $"Expected error but got: {s}"
    | Error e ->  Assert.That(e, Is.EqualTo(expected))

// Test getFromWeb with invalid url
[<Test>]
let ``getFromWeb with invalid url`` () =
    let expected = "URL must start with http:// or https://"
    match getFromWeb "invalid_url" with
    | Ok s ->  Assert.Fail $"Expected error but got: {s}"
    | Error e ->  Assert.That(e, Is.EqualTo(expected))

// Test getFromWeb with valid url
[<Test>]
let ``getFromWeb with valid url`` () =
    let expected = "div [] [\n  str \"Test\"\n]\n"
    let actual = 
        match "http://www.example.com" |> getFromWeb with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Length, Is.GreaterThan(0))   

// Test getFromWeb with non-existent url
[<Test>]
let ``getFromWeb with non-existent url`` () =
    let expected = "The remote server returned an error: (404) Not Found."
    match getFromWeb "http://www.nonexistentwebsite.com" with
    | Ok s ->  Assert.Fail $"Expected error but got: {s}"
    | Error e ->  Assert.That(e.Contains("exception:"), Is.EqualTo(true))

// Test pre tag
[<Test>]
let ``getFromString with pre tag`` () =
    let expected = "pre [] [\n  str \"Preformatted text\"\n]\n"
    let actual = 
        match "<pre>Preformatted text</pre>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test style tag
[<Test>]
let ``getFromString with style tag`` () =
    let expected = "style [] [\n  str \"body { background-color: #fff; }\"\n]\n"
    let actual = 
        match "<style>body { background-color: #fff; }</style>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for svg tag
[<Test>]
let ``getFromString with svg tag`` () =
    let actual = 
        match "<svg aria-hidden=\"true\" class=\"kTpHl\" focusable=\"false\" height=\"1em\" width=\"1em\"><use xlink:href=\"#icon-weather-bom\"></use></svg>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Substring(0, 7), Is.EqualTo("rawText"))

// Test meta tag with http-equiv
[<Test>]
let ``getFromString with meta tag and http-equiv`` () =
    let expected = "meta [_httpEquiv \"X-UA-Compatible\"; _content \"IE=edge\"]\n"
    let actual = 
        match "<meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for mouse events
[<Test>]
let ``getFromString with mouse events`` () =
    let expected = "div [_onclick \"handleClick\"; _onmouseover \"handleMouseOver\"] []\n"
    let actual = 
        match "<div onclick=\"handleClick\" onmouseover=\"handleMouseOver\"></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for flag attributes
[<Test>]
let ``getFromString with flag attributes`` () =
    let expected = "input [_checked; _disabled]\n"
    let actual = 
        match "<input checked disabled>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test get from file with valid file
[<Test>]
let ``getFromFile with valid file`` () =
    let expected = "html [] [\n  body [] [\n    h1 [] [\n      str \"My First Heading\"\n    ]\n    p [] [\n      str \"My first paragraph.\"\n    ]\n  ]\n]\n"
    let actual = 
        match "sample.html" |> getFromFile with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for multiple classes and ids
[<Test>]
let ``getFromString with multiple classes and id`` () =
    let expected = "div [_class \"foo bar\"; _id \"main\"]  [\n  str \"Content\"\n]\n"
    let actual =
        match "<div class=\"foo bar\" id=\"main\">Content</div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for custom attributes
[<Test>]
let ``getFromString with custom attributes`` () =
    let expected = "div [_custom-attr \"value\"] []\n"
    let actual =
        match "<div custom-attr=\"value\"></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for deeply nested elements
[<Test>]
let ``getFromString deeply nested elements`` () =
    let expected = "div [] [\n  ul [] [\n    li [] [\n      span [] [\n        str \"Item\"\n      ]\n    ]\n  ]\n]\n"
    let actual =
        match "<div><ul><li><span>Item</span></li></ul></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for boolean attribute with value
[<Test>]
let ``getFromString boolean attribute with value`` () =
    let expected = "input [_checked]\n"
    let actual =
        match "<input checked=\"checked\">" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for self-closing custom tag
[<Test>]
let ``getFromString self-closing custom tag`` () =
    let expected = "mytag []\n"
    let actual =
        match "<mytag />" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))

// Test for text node with special characters
[<Test>]
let ``getFromString text node with special characters`` () =
    let expected = "div [] [\n  str \"<>&\\\"'\"\n]\n"
    let actual =
        match "<div><>&\"'</div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for multiple root elements
[<Test>]
let ``getFromString with multiple root elements`` () =
    let expected = "div [] []\nspan [] []\n"
    let actual =
        match "<div></div><span></span>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for whitespace handling
[<Test>]
let ``getFromString with whitespace`` () =
    let expected = "div [] [\n  str \"Test\"\n]\n"
    let actual =
        match "<div>   Test   </div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for comment between elements
[<Test>]
let ``getFromString with comment between elements`` () =
    let expected = "div [] [\n  str \"A\"\n  rawText \"\"\"<!-- comment -->\"\"\";\n  str \"B\"\n]\n"
    let actual =
        match "<div>A<!-- comment -->B</div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for input with no attributes
[<Test>]
let ``getFromString input with no attributes`` () =
    let expected = "input []\n"
    let actual =
        match "<input>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Trim(), Is.EqualTo(expected.Trim()))
