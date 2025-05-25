
## HTML to Giraffe
This solution is a collection of tools helpers etc to convert HTML to Giraffe views. They came about from having to convert a PHP to Giraffe.ViewEngine, it was a lot of work so I developed these tools.

### h2glib
Is a dll that provides the functionality to convert HTML to Giraffe views. It can process static HTML files, dynamically generated HTML content, or raw HTML strings.

### h2g
Is a console app that provides a command-line interface to h2glib, allowing users to specify input HTML files, strings, or web pages and convert them to Giraffe views.

### h2gtest
Contains all of the tests that are used for this project.

### gdummy
Is a console app that you can add Giraffe views to and verify their correctness through visual inspection. There are a couple of example conversions in Program.fs.

### Giraffe.Deprecated
Giraffe.ViewEngine doesn't support deprecated HTML elements or attributes. When converting existing HTML you may not have the luxury of fixing all the deprecations in the HTML. This dll contains Giraffe.ViewEngines functions that describe all the deprecated HTML elements & attributes. You need to use these functions to handle deprecated elements and attributes in your Giraffe views.

```text
open Giraffe.ViewEngine
open Giraffe.ViewEngine.Accessibility
open Giraffe.Deprecated
```

in the source file that has deprecated elements or attributes.

### Limitations
- HtmlAgilityPack is used to parse the HTML, if it cannot be parsed by HtmlAgilityPack then you aren't going to get output.
- As my ability to test the code on a large array of websites is limited you may find that there will be errors.
- Websites that contain user-defined attributes may not work. For example, if you use HTMX (a library for adding AJAX, CSS transitions, and more to HTML), you are likely going to experience issues. Learn more about HTMX at [https://htmx.org](https://htmx.org).



