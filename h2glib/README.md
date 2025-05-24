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
html [_lang "en"]  [
  head [] [
    meta [_charset "utf-8"]
    meta [_name "viewport"; _content "width=device-width, initial-scale=1"]
    meta [_name "color-scheme"; _content "light dark"]
    meta [_name "author"; _content "Wayne Innes"]
    link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/bootstrap@5.3.5/dist/css/bootstrap.min.css"; _integrity "sha384-SgOJa3DmI69IUzQ2PVdRZhwQ+dy64/BUtbMJw1MZ8t5HZApcHrRKUc4W0kG879m7"; _crossorigin "anonymous"]
    link [_rel "stylesheet"; _href "/css/mynewwebsite.css"]
    link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/simplemde/latest/simplemde.min.css"]
    title [] [
      str "Login"
    ]
  ]
  body [] [
    header [] [
      nav [_class "navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-company-red border-bottom box-shadow mb-3"]  [
        div [_class "container-fluid"]  [
          a [_class "navbar-brand"; _href "#"]  [
            str "WLI"
          ]
          button [_class "navbar-toggler"; _type "button"; _data "bs-toggle" "collapse"; _data "bs-target" "#navbarNav"; _ariaControls "navbarNav"; _ariaExpanded "false"; _ariaLabel "Toggle navigation"]  [
            span [_class "navbar-toggler-icon"] []
          ]
          div [_class "collapse navbar-collapse"; _id "navbarNav"]  [
            ul [_class "navbar-nav me-auto mb-2 mb-lg-0"]  [
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/home"]  [
                  str "Home"
                ]
              ]
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/golf"]  [
                  str "Golf"
                ]
              ]
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/blogs"]  [
                  str "Blogs"
                ]
              ]
              li [_class "nav-item"]  [
                a [_class "nav-link"; _href "/visited"]  [
                  str "Visited"
                ]
              ]
            ]
          ]
        ]
      ]
    ]
    main [_class "container-fluid"]  [
      div [_class "mx-auto p-2 col-md-4 border rounded"]  [
        h3 [] [
          str "Login"
        ]
        form [_action "/dologin"; _method "post"]  [
          div [_class "w-auto"]  [
            div [_class "mb-3"]  [
              label [_class "form-label"; _for "email"]  [
                str "Email Address"
              ]
              input [_class "form-control"; _type "text"; _id "email"; _name "email"; _value ""; _required]
            ]
          ]
          div [_class "mb-3"]  [
            label [_class "form-label"; _for "password"]  [
              str "Password"
            ]
            div [_class "input-group"]  [
              input [_class "form-control"; _type "password"; _id "password"; _name "password"; _required]
              span [_class "input-group-text bi-eye-slash"; _id "togglePassword-password"; _style "cursor: pointer;"] []
            ]
          ]
          div [_class "m-1 row"]  [
            div [] []
            div [] [
              button [_type "submit"; _value "login"; _id "btnSubmit"; _class "btn btn-primary m-2"]  [
                str "Login"
              ]
            ]
          ]
        ]
      ]
    ]
    footer [_class "container-fluid"]  [
      div [_class "ms-4"]  [
        hr []
        small [] [
          str "&#169; 2025 Wayne Innes"
        ]
      ]
    ]
    script [_src "https://cdn.jsdelivr.net/npm/bootstrap@5.3.5/dist/js/bootstrap.bundle.min.js"; _integrity "sha384-k6d4wzSIapyDyv1kpU366/PK5hCdSbCRGRCMv+eplOQJWyd1fbcAu9OCUj5zNLiq"; _crossorigin "anonymous"]  [
    ]
    script [_src "https://cdn.tiny.cloud/1/ixf31ja444m6qxs1pewq1jixp57vt290az8r65dltenyb2lu/tinymce/6/tinymce.min.js"]  [
    ]
    link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css"]
  ]
```

### Return Value
All of the above functions return a Result<string, string> 
 
Ok will be code that can be used in Giraffe.ViewEngine. 

Error will contain a message as to what went wrong. These errors will either be html parsing errors or exception messages. Parse errors take this form "Start tag <div> was not found at line 1 column 6". Exception errors will be the message from the exception or possibly the result of a parameter validation.
