module ShabbatTests

open System
open System.IO
open NUnit.Framework
open FsUnit
open DNix.Kriah.Core

[<Test>]
let ``Gets items`` () =
    let data = File.ReadAllText("./hebcal-data.json")
    let result = Parshiot.Parse(data)
    let parasha = Seq.find (fun (x: Parshiot.Reading) -> x.Title = "Shemot") result
    let shabbat = Shabbat.parashaToShabbat parasha
    shabbat.Date |> should equal (new DateTime(2018, 1, 6))
    shabbat.Title |> should equal "Shemot"
    shabbat.Id.IsNone |> should be True

