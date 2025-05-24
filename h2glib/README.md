# H2GLIB
A functional ASP.NET Core assembly for converting HTML to Giraffe.ViewEngine DSL.

This dll has three functions

- getFromString htmlStr
- getFromFile fileName
- getFromWeb url

### getFromString str
Takes a html fragment as a string and returns a Result<string, string>

```fsharp
    "<div>Some Text<hr></div>" |> getFromString

    returns

    div [] [
        str "Some Text"
        hr []
    ]

    "<input checked type=\"checkbox\" value=\"1\" />" |> getFromString

    returns
    
    input [_checked; _type "checkbox"; _value "1"]
```

### getFromFile
Opens a file containing a html fragment or a complete html and converts it to source that can be used in Giraffe.ViewEngine

### getFromWeb
Opens a url fetches the  html document and converts it to source that can be used in Giraffe.ViewEngine. Example return from www.example.com

```fsharp
html [] [
  head [] [
    title [] [
      str "Example Domain"
    ]
    meta [_charset "utf-8"]
    meta [_httpEquiv "Content-type"; _content "text/html; charset=utf-8"]
    meta [_name "viewport"; _content "width=device-width, initial-scale=1"]
    style [_type "text/css"]  [
      str "body {
        background-color: #f0f0f2;
        margin: 0;
        padding: 0;
        font-family: -apple-system, system-ui, BlinkMacSystemFont, \"Segoe UI\", \"Open Sans\", \"Helvetica Neue\", Helvetica, Arial, sans-serif;
        
    }
    div {
        width: 600px;
        margin: 5em auto;
        padding: 2em;
        background-color: #fdfdff;
        border-radius: 0.5em;
        box-shadow: 2px 3px 7px 2px rgba(0,0,0,0.02);
    }
    a:link, a:visited {
        color: #38488f;
        text-decoration: none;
    }
    @media (max-width: 700px) {
        div {
            margin: 0 auto;
            width: auto;
        }
    }"
    ]
  ]
  body [] [
    div [] [
      h1 [] [
        str "Example Domain"
      ]
      p [] [
        str "This domain is for use in illustrative examples in documents. You may use this
    domain in literature without prior coordination or asking for permission."
      ]
      p [] [
        a [_href "https://www.iana.org/domains/example"]  [
          str "More information..."
        ]
      ]
    ]
  ]
]
```

### Return Value
All of the above functions return a Result<string, string> 
 
Ok will be code that can be used in Giraffe.ViewEngine. 

Error will contain a message as to what went wrong. These errors will either be html parsing errors or exception messages. Parse errors take this form "Start tag <div> was not found at line 1 column 6". Exception errors will be the message from the exception or possibly the result of a parameter validation.
