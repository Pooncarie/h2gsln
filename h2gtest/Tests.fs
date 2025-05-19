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
    let expected = "div [_dataTest \"abc\"; _ariaLabel \"label\"; _hxPost \"/api\"] []\n"
    let actual = 
        match "<div data-test=\"abc\" aria-label=\"label\" hx-post=\"/api\"></div>" |> getFromString with
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
    let expected = "body [] [\n]\n"
    let actual = 
        match "<body><!-- a comment --></body>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

[<Test>]
// Test for role attribute
let ``getFromString with role attribute`` () =
    let expected = "div [_role \"button\"] []\n"
    let actual = 
        match "<div role=\"button\"></div>" |> getFromString with
        | Ok s -> s
        | Error e -> failwith e
    Assert.That(actual.Replace("\r\n", "\n"), Is.EqualTo(expected.Replace("\r\n", "\n")))

// Test for script tag
[<Test>]
let ``getFromString with script tag`` () =
    let expected = "script [] [\n  str \"console.log('Hello World');\"\n]\n"
    let actual = 
        match "<script>console.log('Hello World');</script>" |> getFromString with
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
let ``getFromString with aria attributes`` () =
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

// Test for null html
[<Test>]
let ``getFromString with null html`` () =
    let expected = "HTML string cannot be null"
    match getFromString null with
    | Ok actual -> Assert.Fail $"Expected error but got: {actual}"
    | Error e -> Assert.That(e, Is.EqualTo(expected))

// Test for empty html
[<Test>]
let ``getFromString with empty html`` () =
    let expected = "HTML string cannot be empty"
    match "" |> getFromString with
    | Ok s ->  Assert.Fail $"Expected error but got: {s}"
    | Error e ->  Assert.That(e, Is.EqualTo(expected))

[<Test>]
let ``getFromFile with null html`` () =
    let expected = "File path cannot be null"
    match getFromFile null with
    | Ok actual -> Assert.Fail $"Expected error but got: {actual}"
    | Error e -> Assert.That(e, Is.EqualTo(expected))

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

// Test getFromWeb with null url
[<Test>]
let ``getFromWeb with null url`` () =
    let expected = "URL cannot be null"
    match getFromWeb null with
    | Ok actual -> Assert.Fail $"Expected error but got: {actual}"
    | Error e -> Assert.That(e, Is.EqualTo(expected))

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