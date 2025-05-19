open Giraffe.ViewEngine
open Giraffe.ViewEngine.Accessibility

let private _dataBsToggle = attr "data-bs-target"
let private _dataBsTarget = attr "data-bs-toggle"

let f1 = 
  html [_lang "en"]  [
    head [] [
      meta [_charset "utf-8"]
      meta [_name "viewport"; _content "width=device-width, initial-scale=1"]
      meta [_name "color-scheme"; _content "light dark"]
      link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/bootstrap@5.3.5/dist/css/bootstrap.min.css"; _integrity "sha384-SgOJa3DmI69IUzQ2PVdRZhwQ+dy64/BUtbMJw1MZ8t5HZApcHrRKUc4W0kG879m7"; _crossorigin "anonymous"]
      link [_rel "stylesheet"; _href "/css/mynewwebsite.css"]
      link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/simplemde/latest/simplemde.min.css"]
      title [] [
        str "Home"
      ]
    ]
    body [] [
      header [] [
        nav [_class "navbar navbar-expand-sm navbar-toggleable-sm navbar-dark bg-company-red border-bottom box-shadow mb-3"]  [
          div [_class "container-fluid"]  [
            a [_class "navbar-brand"; _href "#"]  [
              str "WLI"
            ]
            button [_class "navbar-toggler"; _type "button"; _dataBsToggle "collapse"; _dataBsTarget "#navbarNav"; _ariaControls "navbarNav"; _ariaExpanded "false"; _ariaLabel "Toggle navigation"]  [
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
        div [_class "container-fluid"; _id "conta"]  [
          div [] [
            div [_class "mt-2"]  [
              span [] [
                span [_class "h2"]  [
                  str "John Ardley"
                ]
                span [_class "ms-2"; _style "font-size: 8pt;"]  [
                  str "2025-05-01"
                ]
              ]
              div [_class "mt-2"]  [
                p [] [
                  str "On my fathers side of the family John Ardley was the first of my ancestors to arrive in Australia. He was born in Coggeshall, Essex, England on 11 April 1807. He married Mary Gamble on 17 Feburary 1825, they had two children Eliza &amp; William."
                ]
                p [] [
                  str "On the 13th December 1828 he was convicted for stealing. A newspaper report from The Standard, London says"
                ]
                p [] [
                  str "\"John Ardley was indicted for having, in company with another person unknown, broken and entered the dwelling house of Francis Ruffle, of Earl's Colne, and stealing therefrom a pocket book, containing a 5/- Bank of England note, a 5/- note of the Braintree Bank, 5/- 10s in sovereigns and half sovereigns, and 11/- 1s in silver, and various other property. The prisoner, in his defence, denied all knowledge of the robbery. The jury returned a verdict of Guilty. Mr Justice Burrough directed judgment of death to be recorded against the prisoner, and at the same time intimated to him, that although his life would be spared, he must expect to leave the country for life.\""
                ]
                p [] [
                  str "He didn&rsquo;t want to go to Australia as this story from the Essex Herald dated 27th January 1829 makes clear."
                ]
                p [] [
                  str "&ldquo;An attempt was made on Friday night week by Ardley, convicted of the burglary at Earls Colne, and sentenced to transportation for life, who was confined in a cell with two others, to penetrate the wall of his cell. He had evidently worked hard the whole of the night; his labour, however, but ill repaid him. He had removed, apparently with a chisel, the interior course of bricks, about 12 inches square ;.having accomplished thus much, his difficulties increased, by the tight manner in which the bricks were wedged in, as well as by the weight above them; the want of room to give effect to his tool was also another obstacle. It was suspected that two men, who slept in the same cell with Ardley, had assisted in making the breach, but their declarations to the contrary, and the circumstance of their periods of imprisonment expiring within a few days, gave a favourable colour to their plea of being asleep during the time Ardley laboured, or they had been tried for aiding and assisting in the escape of a prisoner, and, if convicted, might have been transported for life. The attempt has now been made, for the first time, to get out, and the result will, without doubt, operate as a convincing proof escape impracticable. Had Ardley succeeded in penetrating the wall of his cell, he would have been at least 25 feet from the ground; and would have still been opposed in his escape by the exterior wall of the prison, which is about 20 feet high. Ardley was among the transportees removed on Tuesday morning.&rdquo;"
                ]
                p [] [
                  str "He arrived in Australia 9th July 1829. He was described as being a &ldquo;Fisherman and Labourer, 5 feet 5, ruddy freckled complexion, brown hair, with light hazel eyes&rdquo; He was assigned to various people and eventually ended up in the Canberra / Monaro region."
                ]
                p [] [
                  str "Below are copies of &ldquo;Ticket of Leave&rdquo; that he was given (click on them to see them full size). They were all given at Queanbeyan Courthouse. He died on the 25th December 1846 at Maneroo. I am not sure if Maneroo is a station or simply refers to the Monaro region (Maneroo was an early name for the Monaro). &nbsp;There is an image below of that is a list of unclaimed letters showing him living at Maneroo."
                ]
                p [] [
                  str "His brothers William &amp; Robert were also transported to Australia as convicts. At various time his sister Francis (accompied by John's daughter Eliza), brother Samuel and son William all emigrated to Australia."
                ]
                div [_class "row"]  [
                  div [_class "col"]  [
                    a [_href "../../images/IMG_0507.jpg"; _target "_blank"; _rel "noopener"]  [
                      img [_class "rounded"; _src "../../images/IMG_0507.jpg"; _alt ""; _width "200"; _height "300"]
                    ]
                  ]
                  div [_class "col"]  [
                    a [_href "../../images/IMG_0508.jpg"; _target "_blank"; _rel "noopener"]  [
                      img [_class "rounded"; _src "../../images/IMG_0508.jpg"; _alt ""; _width "200"; _height "300"]
                    ]
                  ]
                  div [_class "col"]  [
                    a [_href "../../images/IMG_0511.jpg"; _target "_blank"; _rel "noopener"]  [
                      img [_class "rounded"; _src "../../images/IMG_0511.jpg"; _alt ""; _width "200"; _height "300"]
                    ]
                  ]
                  div [_class "col"]  [
                    a [_href "../../images/JohnArdleyManeroo.jpg"; _target "_blank"; _rel "noopener"]  [
                      img [_class "rounded"; _src "../../images/JohnArdleyManeroo.jpg"; _alt ""; _width "200"; _height "300"]
                    ]
                  ]
                ]
              ]
            ]
            div [_class "mt-2"]  [
              span [] [
                span [_class "h2"]  [
                  str "Oops I did it again"
                ]
                span [_class "ms-2"; _style "font-size: 8pt;"]  [
                  str "2025-04-11"
                ]
              ]
              div [_class "mt-2"]  [
                p [] [
                  str "PHP &amp; Htmx are all ok, but my real expertise lies in the .NET environment. One of the interests I have always had was in functional programming and revamping this website in F# seemed like a great opportunity for me to explore functional programming. So here it is, written in F# using&nbsp;"
                  a [_href "https://giraffe.wiki/docs"; _target "_blank"; _rel "noopener"]  [
                    str "Giraffe"
                  ]
                  str ". It also seemed like a good time to have a look at"
                  a [_href "https://www.cloudflare.com/en-au/"; _target "_blank"; _rel "noopener"]  [
                    str "Cloudflare"
                  ]
                  str ", you now accessing this site through Cloudflare."
                ]
              ]
            ]
            div [_class "mt-2"]  [
              span [] [
                span [_class "h2"]  [
                  str "Im back after a short break."
                ]
                span [_class "ms-2"; _style "font-size: 8pt;"]  [
                  str "2023-05-16"
                ]
              ]
              div [_class "mt-2"]  [
                p [] [
                  str "I created this website in 2013 to record a trip that I made around Australia. When I finished it I got a bit slack and didn't add new content. However I did use the site to explore different web based technologies, it has variously been rewritten as plain HTML, python CGI, Mithril, Angular, ASP.NET, PHP &amp; htmx. Currently it is a mixture of htmx and PHP. Anyway I am going to to start adding new content at some stage or maybe I won't."
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
  ]


