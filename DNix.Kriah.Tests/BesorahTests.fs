module DNix.Kriah.Tests.BesorahTests

open System
open System.IO
open NUnit.Framework
open DNix.Kriah.Core
open FsUnit
// open DNix.Kriah.Core.Besorot

let GetCycle cycleString = 
    match cycleString with
    | "A" -> Besorot.Year.A
    | "B" -> Besorot.Year.B
    | _ -> Besorot.Year.C

[<SetUp>]
let Setup () =
    ()

[<Test>]
[<TestCase(5777)>]
[<TestCase(5778)>]
[<TestCase(5782)>]
let ``Bereshit always has the beginning of John`` (year) =
    let result = Besorot.GetReadingBySedra year "Bereshit" None
    "John 1:1-18" |> should equal (Option.get(result).Reading)

[<TestCase(5777, "A")>]
[<TestCase(5778, "B")>]
[<TestCase(5779, "C")>]
[<TestCase(5780, "A")>]
[<TestCase(5782, "C")>]
let ``Chooses correct cycle based on year`` (year: int, cycleString: string) =
    let cycle = 
        match cycleString with
        | "A" -> Besorot.Year.A
        | "B" -> Besorot.Year.B
        | _ -> Besorot.Year.C

    let readingYear = Besorot.GetYear year
    cycle |> should equal readingYear


[<TestCase("Yitro", 5782, "John 7:1-13")>]
[<TestCase("Vayechi", 5781, "Luke 5:27-39")>]
let ``Can get a few normals ones right`` (sedra: string, year: int, expected: string) =
    let result = Besorot.GetReadingBySedra year sedra None
    expected |> should equal (Option.get(result).Reading)

[<TestCase("Mishpatim", 5782)>]
[<TestCase("Vayakhel", 5782)>]
let ``Can get shabbat shekalim right`` (sedra: string, year: int) =
    let expected = "Mark 12:41-44"
    let result = Besorot.GetReading year {Sedra = sedra; Shabbat = Some Besorot.SpecialShabbat.Shekalim}
    result.Value.Reading |> should equal expected

