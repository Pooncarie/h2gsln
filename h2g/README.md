## h2g
Is a console app that provides a simple interface to h2glib dll.

Options
    -w  Fetch a web page and convert it
    -f  Open a file and convert its contents
    -s  Convert the html fragment provided
    -h  Help screen

```text
/h2g -w https://www.google.com.au
html [_itemscope ""; _itemtype "http://schema.org/WebPage"; _lang "en-AU"]  [
  head [] [
    meta [_content "text/html; charset=UTF-8"; _httpEquiv "Content-Type"]
    meta [_content "/images/branding/googleg/1x/googleg_standard_color_128dp.png"; _itemprop "image"]
    title [] [
      str "Google"
    ]
    script [_nonce "dnpSPWpLl_1d_wM49AT92g"]  [

    etc.........
```

```text

if sample.html contains

    <!DOCTYPE html>
    <html>
    <body>

    <h1>My First Heading</h1>

    <p>My first paragraph.</p>

    </body>
    </html>

then

% ./h2g -f sample.html 
html [] [
  body [] [
    h1 [] [
      str "My First Heading"
    ]
    p [] [
      str "My first paragraph."
    ]
  ]
]

```

```text
./h2g -s "<section><div>Some Text</div></section>"
section [] [
  div [] [
    str "Some Text"
  ]
]
```

```text
% ./h2g -h
Usage: h2g.exe -w|-f|-s <input>
  -w: Get HTML from a web URL
  -f: Get HTML from a file
  -s: Get HTML from a string
'''