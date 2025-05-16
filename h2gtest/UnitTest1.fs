module h2gtest

open h2glib
open NUnit.Framework

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    Assert.Pass()
