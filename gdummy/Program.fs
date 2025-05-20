open Giraffe.ViewEngine
open Giraffe.ViewEngine.Accessibility

let  _bgcolor = attr "bgcolor"
let  _cellpadding = attr "cellpadding"
let  _cellspacing = attr "cellspacing"
let  _align = attr "align"
let  _valign = attr "valign"
let  _autocapitalize = attr "autocapitalize"
let  _autocorrect = attr "autocorrect"
let _op = attr "op"
let _language = attr "language"

let  center = tag "center"

let f1 = 
 html [] [
  head [] [
    meta [_httpEquiv "Content-Type"; _content "text/html; charset=iso-8859-1"]
    title [] [
      str "Riverside Golf Club | OneGolf"
    ]
    meta [_name "viewport"; _content "width=device-width, initial-scale=1, shrink-to-fit=no"]
    link [_href "https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,400;0,500;0,700;0,900;1,100;1,300;1,400;1,500;1,700;1,900&display=swap"; _rel "stylesheet"]
    link [_href "https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css"; _rel "stylesheet"; _integrity "sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC"; _crossorigin "anonymous"]
    script [_type "text/javascript"; _src "/scripts/miclub.js"]  [
    ]
    link [_href "/style/productStyle/privateClubProduct.css"; _rel "stylesheet"; _type "text/css"]
    link [_href "/style/cms.css"; _rel "stylesheet"; _type "text/css"]
    link [_href "/style/custom.css"; _rel "stylesheet"; _type "text/css"]
    link [_href "/style/p7pmh0.css"; _rel "stylesheet"; _type "text/css"]
  ]
  body [_class "oneGolf"]  [
    nav [] [
      div [_class "logo"]  [
        img [_src "/product-images/onegolf-logo.png"; _alt "logo"]
      ]
      div [_class "menu"]  [
        ul [] [
          li [] [
            a [_href "/security/login.msp"]  [
              str "Home"
            ]
          ]
          li [] [
            a [_href "https://www.miclub.com.au/cms/solutions-services/golf-management/onegolf/"; _target "_blank"]  [
              str "About OneGolf"
            ]
          ]
          li [] [
            a [_href "/guests/contact.mhtml"]  [
              str "Contact"
            ]
          ]
          li [] [
            a [_href "https://1golfhelp.miclub.com.au/support/solutions/folders/14000127940"; _target "_blank"]  [
              str "Help"
            ]
          ]
        ]
      ]
      a [_id "openOffcanvasBtn"; _class "hamburger-menu"; _data "bs-toggle" "offcanvas"; _href "#offcanvasExample"; _roleButton; _ariaControls "offcanvasExample"]  [
        span [_class "bar"] []
        span [_class "bar"] []
        span [_class "bar"] []
      ]
      div [_id "offcanvasBackdrop"; _style "position: fixed; top: 0; left: 0; width: 100vw; height: 100vh; background-color: rgba(0,0,0,0.5); visibility: hidden; z-index: 1040;"] []
      div [_class "offcanvas offcanvas-start"; _tabindex "-1"; _id "offcanvasExample"; _ariaLabelledBy "offcanvasExampleLabel"]  [
        div [_class "offcanvas-header"]  [
          button [_id "offcanvasCloseBtn"; _type "button"; _class "btn-close text-reset"; _data "bs-dismiss" "offcanvas"; _ariaLabel "Close"]  [
            span [_class "bar"] []
            span [_class "bar"] []
          ]
        ]
        div [_class "offcanvas-body"]  [
          div [] [
            ul [] [
              li [] [
                a [_href "/security/login.msp"]  [
                  str "Home"
                ]
              ]
              li [] [
                a [_href "https://www.miclub.com.au/cms/solutions-services/golf-management/onegolf/"; _target "_blank"]  [
                  str "About OneGolf"
                ]
              ]
              li [] [
                a [_href "/guests/contact.mhtml"]  [
                  str "Contact"
                ]
              ]
              li [] [
                a [_href "https://1golfhelp.miclub.com.au/support/solutions/folders/14000127940"; _target "_blank"]  [
                  str "Help"
                ]
              ]
            ]
          ]
        ]
      ]
    ]
    div [_class "login-page"]  [
      div [_class "login-section"]  [
        div [_class "contanier col-50 brand"]  [
          div [_class "title-section"]  [
            h1 [_class "title"]  [
              str "Welcome to Members of"
              br []
              str "Riverside Golf Club"
            ]
          ]
          div [_class "login-container"]  [
            div [_id "error"]  [
            ]
            form [_action "/security/login.msp"; _method "post"; _name "form"; _id "form"]  [
              div [_class "form-group"]  [
                label [_for "username"]  [
                  str "Membership No."
                ]
                input [_name "action"; _type "hidden"; _id "action"; _value "login"]
                input [_autocomplete "on"; _type "text"; _name "user"; _value ""; _size "11"; _maxlength "32"; _placeholder "Type here..."]
              ]
              div [_class "form-group"]  [
                label [_for "username"]  [
                  str "Password"
                ]
                input [_name "action"; _type "hidden"; _id "action"; _value "password"]
                input [_autocomplete "on"; _type "password"; _name "password"; _value ""; _size "11"; _maxlength "64"; _placeholder "Type here..."]
              ]
              div [_class "button-container"]  [
                input [_type "submit"; _value "Sign In"; _border "0"; _alt "Sign In"; _name "Sign In"; _id "submitBtn"]
                a [_class "btn-dark"; _href "/security/passwordReminder.msp"]  [
                  str "Forgot Password"
                ]
              ]
              p [_class "help"]  [
                a [_href "https://1golfhelp.miclub.com.au/support/solutions/articles/14000151370-login-help-for-onegolf"; _target "_blank"]  [
                  str "Need help logging on?"
                ]
              ]
            ]
          ]
        ]
        div [_class "container text-section col-50 black"]  [
          div [_class "text-container"]  [
            p [] [
              str "Your username is your membership number (the last four digits of your Golflink number removing leading 0s. e.g. 0035 becomes 35) and your new password is now your birth day and month (e.g. \"0705\" for 7 May). If this is unsuccessful, try the default password of 0101 then update your Date of Birth once logged in and also change the password to match this."
            ]
            h2 [] [
              str "Terms and Conditions"
            ]
            p [] [
              str "This Web site is provided by Riverside Golf Club. By using the site or downloading materials from the site, you agree to abide by the"
              a [_href "/guests/terms/terms_conditions.mhtml"]  [
                str "terms and conditions"
              ]
              str "."
            ]
          ]
        ]
      ]
    ]
    footer [_id "footerArea"]  [
      p [_class "footerLeft footer-col"]  [
        a [_href "https://www.instagram.com/miclub/"; _target "_blank"]  [
          img [_src "/product-images/onegolf-instagram.png"; _alt "Instagram"]
        ]
        a [_href "https://www.facebook.com/miclubsoftware/"; _target "_blank"]  [
          img [_src "/product-images/onegolf-facebook.png"; _alt "Facebook"]
        ]
        a [_href "https://www.youtube.com/channel/UCMjUZxM8umaCYh26lyV4y6g"; _target "_blank"]  [
          img [_src "/product-images/onegolf-youtube.png"; _alt "Youtube"]
        ]
        a [_href "https://www.linkedin.com/company/2294371/"; _target "_blank"]  [
          img [_src "/product-images/onegolf-linkedin.png"; _alt "Linkedin"]
        ]
      ]
      p [_class "footerCenter footer-col"]  [
        str "&copy; OneGolf 2025 |"
        a [_href "mailto:support@miclub.com.au"]  [
          str "support@miclub.com.au"
        ]
      ]
      p [_class "footerRight footer-col"]  [
        a [_href "http://www.miclub.com.au/welcome/index.mhtml"; _target "_blank"]  [
          img [_src "/product-images/onegolf-miclub-white.png"; _alt "Powered by MiClub Online"]
        ]
        a [_href "https://miscore.com.au/cms/"; _target "_blank"]  [
          img [_src "/product-images/onegolf-miscore-white.png"; _alt "MiScore"]
        ]
        a [_href "https://teenet.com.au/teenet"; _target "_blank"]  [
          img [_src "/product-images/onegolf-teenet-white.png"; _alt "TeeNet"]
        ]
        a [_href "https://www.mitournament.com/"; _target "_blank"]  [
          img [_src "/product-images/onegolf-mitournament-white.png"; _alt "MiTournament"]
        ]
      ]
    ]
    script [] [
      rawText """
  const offcanvas = document.getElementById('offcanvasExample');
  const backdrop = document.getElementById('offcanvasBackdrop');
  const openBtn = document.getElementById('openOffcanvasBtn');
  const closeBtn = document.getElementById('offcanvasCloseBtn');

  var today = new Date();
  var year = today.getFullYear();

  // Open Offcanvas and show backdrop
  openBtn.addEventListener('click', function () {
    backdrop.style.visibility = 'visible';
    offcanvas.classList.add('show');
  });

  // Close Offcanvas and hide backdrop
  function closeOffcanvas() {
    backdrop.style.visibility = 'hidden';
    offcanvas.classList.remove('show');
  }

  // Close Offcanvas when close button is clicked
  closeBtn.addEventListener('click', closeOffcanvas);

  // Close Offcanvas when clicking on the backdrop (outside the Offcanvas)
  backdrop.addEventListener('click', closeOffcanvas);
"""
    ]
    script [_language "JavaScript"; _type "text/javascript"]  [
      rawText """document.forms['form'].elements['user'].focus();"""
    ]
  ]
]




let f2 = RenderView.AsString.htmlNode f1

printfn "%s" f2
