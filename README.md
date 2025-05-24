
## HTML to Giraffe
This soluton is a collection of tools helpers etc to convert HTML to Giraffe views. They came about from having to convert a PHP to Giraffe.ViewEngine, it was a lot of work so I developed these tools.

### h2glib
Is a dll that provides the functionality to convert HTML to Giraffe views. It can convert web pages, html files or html strings.

### h2g
Is a console app that provides a simple interface to h2glib

### h2gtest
Contains all of the tests that are used for this project.

### gdummy
Is a console app that you can add Giraffe views to and ensure that they have converted correctly. There are a couple example conversions in Program.fs

### Giraffe.Deprecated
Giraffe.ViewEngine doesn't support deprecated HTML elements or attributes. When converting existing HTML you may not have the luxury of fixing all the deprecations in the HTML. This dll contains Giraffe.ViewEngines functions that dscribe all the deprecated HTML elements & attributes.



