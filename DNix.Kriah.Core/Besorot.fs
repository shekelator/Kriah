namespace DNix.Kriah.Core
open FSharp.Data
open System

// Start again from https://atlemann.github.io/fsharp/2018/02/28/fsharp-solutions-from-scratch.html

module TypeUtils = 
    open Microsoft.FSharp.Reflection

    let toString (x:'a) = 
        match FSharpValue.GetUnionFields(x, typeof<'a>) with
        | case, _ -> case.Name

    let fromString<'a> (s:string) =
        match FSharpType.GetUnionCases typeof<'a> |> Array.filter (fun case -> case.Name = s) with
        |[|case|] -> Some(FSharpValue.MakeUnion(case,[||]) :?> 'a)
        |_ -> None

module Besorot =

    type Parasha = 
        ``Bereshit``
        |``Noach``
        |``Lech-Lecha``
        |``Vayera``
        |``Chayei Sara``
        |``Toldot``
        |``Vayetzei``
        |``Vayishlach``
        |``Vayeshev``
        |``Miketz``
        |``Vayigash``
        |``Vayechi``
        |``Shemot``
        |``Vaera``
        |``Bo``
        |``Beshalach``
        |``Yitro``
        |``Mishpatim``
        |``Shabbat Shekalim``
        |``Terumah``
        |``Tetzaveh``
        |``Shabbat Zachor``
        |``Erev Purim``
        |``Purim``
        |``Ki Tisa``
        |``Vayakhel-Pekudei``
        |``Vayakhel``
        |``Pekudei``
        |``Shabbat Parah``
        |``Vayikra``
        |``Shabbat HaChodesh``
        |``Tzav``
        |``Shabbat HaGadol``
        |``Pesach I``
        |``Pesach VII``
        |``Pesach VIII``
        |``Shmini``
        |``Tazria-Metzora``
        |``Tazria``
        |``Metzora``
        |``Achrei Mot-Kedoshim``
        |``Achrei Mot``
        |``Kedoshim``
        |``Emor``
        |``Behar-Bechukotai``
        |``Behar``
        |``Bechukotai``
        |``Bamidbar``
        |``Shavuot I``
        |``Shavuot II``
        |``Nasso``
        |``Beha'alotcha``
        |``Sh'lach``
        |``Korach``
        |``Chukat``
        |``Balak``
        |``Pinchas``
        |``Rosh Chodesh Av``
        |``Matot-Masei``
        |``Matot``
        |``Masei``
        |``Devarim``
        |``Shabbat Chazon``
        |``Vaetchanan``
        |``Shabbat Nachamu``
        |``Eikev``
        |``Re'eh``
        |``Shoftim``
        |``Ki Teitzei``
        |``Ki Tavo``
        |``Nitzavim``
        |``Rosh Hashana I``
        |``Rosh Hashana II``
        |``Vayeilech``
        |``Shabbat Shuva``
        |``Erev Yom Kippur``
        |``Yom Kippur``
        |``Ha'Azinu``
        |``Sukkot I``
        |``Sukkot II``
        |``Sukkot VII (Hoshana Raba)``
        |``Shmini Atzeret``
        |``Simchat Torah``
        override this.ToString() = TypeUtils.toString this
        static member FromString(s: string) = TypeUtils.fromString<Parasha> s


    let getParashaFromTitle title =
        Parasha.FromString title


    type Year = A | B | C

    type ReadingRec = { Parasha: Parasha; Reading: string }

    let CycleA = [
        {Parasha = Parasha.``Bereshit``; Reading = "John 1:1-18"}
        {Parasha = Parasha.``Noach``; Reading = "Matthew 1:1-17"}
        {Parasha = Parasha.``Lech-Lecha``; Reading = "Matthew 1:18-25"}
        {Parasha = Parasha.``Vayera``; Reading = "Matthew 2:1-12"}
        {Parasha = Parasha.``Chayei Sara``; Reading = "Matthew 3:1-12"}
        {Parasha = Parasha.``Toldot``; Reading = "Matthew 3:13-4:11"}
        {Parasha = Parasha.``Vayetzei``; Reading = "Mark 1:14-28"}
        {Parasha = Parasha.``Vayishlach``; Reading = "Mark 1:29-45"}
        {Parasha = Parasha.``Vayeshev``; Reading = "Matthew 5:1-16"}
        {Parasha = Parasha.``Miketz``; Reading = "Matthew 5:17-26"}
        {Parasha = Parasha.``Vayigash``; Reading = "Matthew 5:27-48"}
        {Parasha = Parasha.``Vayechi``; Reading = "Matthew 6:1-18"}
        {Parasha = Parasha.``Shemot``; Reading = "Matthew 6:19-34"}
        {Parasha = Parasha.``Vaera``; Reading = "Matthew 7:1-12"}
        {Parasha = Parasha.``Bo``; Reading = "Matthew 7:13-29"}
        {Parasha = Parasha.``Beshalach``; Reading = "Mark 2:1-12"}
        {Parasha = Parasha.``Yitro``; Reading = "Matthew 11:2-19"}
        {Parasha = Parasha.``Mishpatim``; Reading = "Matthew 11:20-30"}
        {Parasha = Parasha.``Terumah``; Reading = "Matthew 13:1-23"}
        {Parasha = Parasha.``Tetzaveh``; Reading = "Matthew 14:12-33"}
        {Parasha = Parasha.``Ki Tisa``; Reading = "Matthew 15:1-20"}
        {Parasha = Parasha.``Vayakhel``; Reading = "Matthew 15:21-28"}
        {Parasha = Parasha.``Pekudei``; Reading = "Matthew 15:29-39"}
        {Parasha = Parasha.``Vayakhel-Pekudei``; Reading = "Matthew 15:21-39"}
        {Parasha = Parasha.``Vayikra``; Reading = ""}
        {Parasha = Parasha.``Tzav``; Reading = ""}
        {Parasha = Parasha.``Shmini``; Reading = ""}
        {Parasha = Parasha.``Tazria-Metzora``; Reading = ""}
        {Parasha = Parasha.``Tazria``; Reading = ""}
        {Parasha = Parasha.``Metzora``; Reading = ""}
        {Parasha = Parasha.``Achrei Mot-Kedoshim``; Reading = ""}
        {Parasha = Parasha.``Kedoshim``; Reading = ""}
        {Parasha = Parasha.``Achrei Mot``; Reading = ""}
        {Parasha = Parasha.``Emor``; Reading = ""}
        {Parasha = Parasha.``Behar``; Reading = ""}
        {Parasha = Parasha.``Bechukotai``; Reading = ""}
        {Parasha = Parasha.``Behar-Bechukotai``; Reading = ""}
        {Parasha = Parasha.``Bamidbar``; Reading = "Mark 12:28-34"}
        {Parasha = Parasha.``Nasso``; Reading = ""}
        {Parasha = Parasha.``Beha'alotcha``; Reading = ""}
        {Parasha = Parasha.``Sh'lach``; Reading = ""}
        {Parasha = Parasha.``Korach``; Reading = ""}
        {Parasha = Parasha.``Chukat``; Reading = ""}
        {Parasha = Parasha.``Balak``; Reading = ""}
        {Parasha = Parasha.``Pinchas``; Reading = ""}
        {Parasha = Parasha.``Matot``; Reading = ""}
        {Parasha = Parasha.``Masei``; Reading = ""}
        {Parasha = Parasha.``Matot-Masei``; Reading = ""}
        {Parasha = Parasha.``Devarim``; Reading = ""}
        {Parasha = Parasha.``Vaetchanan``; Reading = ""}
        {Parasha = Parasha.``Eikev``; Reading = ""}
        {Parasha = Parasha.``Re'eh``; Reading = ""}
        {Parasha = Parasha.``Shoftim``; Reading = ""}
        {Parasha = Parasha.``Ki Teitzei``; Reading = ""}
        {Parasha = Parasha.``Ki Tavo``; Reading = ""}
        {Parasha = Parasha.``Nitzavim``; Reading = ""}
        {Parasha = Parasha.``Vayeilech``; Reading = ""}
        {Parasha = Parasha.``Ha'Azinu``; Reading = ""}
        ]

    let CycleB = [
        {Parasha = Parasha.``Bereshit``; Reading = "John 1:1-18"}
        {Parasha = Parasha.``Noach``; Reading = "Luke 1:26-38"}
        {Parasha = Parasha.``Lech-Lecha``; Reading = "Luke 2:1-20"}
        {Parasha = Parasha.``Vayera``; Reading = "Luke 2:21-40"}
        {Parasha = Parasha.``Chayei Sara``; Reading = "Luke 3:1-17"}
        {Parasha = Parasha.``Toldot``; Reading = "Luke 3:18-38"}
        {Parasha = Parasha.``Vayetzei``; Reading = "Luke 4:1-15"}
        {Parasha = Parasha.``Vayishlach``; Reading = "Luke 4:16-30"}
        {Parasha = Parasha.``Vayeshev``; Reading = "Luke 4:31-44"}
        {Parasha = Parasha.``Miketz``; Reading = "Luke 5:1-11"}
        {Parasha = Parasha.``Vayigash``; Reading = "Luke 5:12-26"}
        {Parasha = Parasha.``Vayechi``; Reading = "Luke 5:27-39"}
        {Parasha = Parasha.``Shemot``; Reading = "Luke 6:1-16"}
        {Parasha = Parasha.``Vaera``; Reading = "Luke 6:17-38"}
        {Parasha = Parasha.``Bo``; Reading = "Luke 7:1-17"}
        {Parasha = Parasha.``Beshalach``; Reading = "Luke 7:18-35"}
        {Parasha = Parasha.``Yitro``; Reading = "Luke 7:36-50"}
        {Parasha = Parasha.``Mishpatim``; Reading = "Luke 8:1-21"}
        {Parasha = Parasha.``Terumah``; Reading = "Luke 8:22-39"}
        {Parasha = Parasha.``Tetzaveh``; Reading = "Luke 8:40-56"}
        {Parasha = Parasha.``Ki Tisa``; Reading = "Luke 9:1-17"}
        {Parasha = Parasha.``Vayakhel``; Reading = "Luke 9:18-27"}
        {Parasha = Parasha.``Pekudei``; Reading = "Luke 9:28-36"}
        {Parasha = Parasha.``Vayakhel-Pekudei``; Reading = "Luke 9:18-36"}
        {Parasha = Parasha.``Vayikra``; Reading = ""}
        {Parasha = Parasha.``Tzav``; Reading = ""}
        {Parasha = Parasha.``Shmini``; Reading = ""}
        {Parasha = Parasha.``Tazria-Metzora``; Reading = ""}
        {Parasha = Parasha.``Tazria``; Reading = ""}
        {Parasha = Parasha.``Metzora``; Reading = ""}
        {Parasha = Parasha.``Achrei Mot-Kedoshim``; Reading = ""}
        {Parasha = Parasha.``Kedoshim``; Reading = ""}
        {Parasha = Parasha.``Achrei Mot``; Reading = ""}
        {Parasha = Parasha.``Emor``; Reading = ""}
        {Parasha = Parasha.``Behar``; Reading = ""}
        {Parasha = Parasha.``Bechukotai``; Reading = ""}
        {Parasha = Parasha.``Behar-Bechukotai``; Reading = ""}
        {Parasha = Parasha.``Bamidbar``; Reading = "Luke 16:19-31"}
        {Parasha = Parasha.``Nasso``; Reading = ""}
        {Parasha = Parasha.``Beha'alotcha``; Reading = ""}
        {Parasha = Parasha.``Sh'lach``; Reading = ""}
        {Parasha = Parasha.``Korach``; Reading = ""}
        {Parasha = Parasha.``Chukat``; Reading = ""}
        {Parasha = Parasha.``Balak``; Reading = ""}
        {Parasha = Parasha.``Pinchas``; Reading = ""}
        {Parasha = Parasha.``Matot``; Reading = ""}
        {Parasha = Parasha.``Masei``; Reading = ""}
        {Parasha = Parasha.``Matot-Masei``; Reading = ""}
        {Parasha = Parasha.``Devarim``; Reading = ""}
        {Parasha = Parasha.``Vaetchanan``; Reading = ""}
        {Parasha = Parasha.``Eikev``; Reading = ""}
        {Parasha = Parasha.``Re'eh``; Reading = ""}
        {Parasha = Parasha.``Shoftim``; Reading = ""}
        {Parasha = Parasha.``Ki Teitzei``; Reading = ""}
        {Parasha = Parasha.``Ki Tavo``; Reading = ""}
        {Parasha = Parasha.``Nitzavim``; Reading = ""}
        {Parasha = Parasha.``Vayeilech``; Reading = ""}
        {Parasha = Parasha.``Ha'Azinu``; Reading = ""}
        ]

    let CycleC = [
        {Parasha = Parasha.``Bereshit``; Reading = "John 1:1-18"}
        {Parasha = Parasha.``Noach``; Reading = "John 1:19-34"}
        {Parasha = Parasha.``Lech-Lecha``; Reading = "John 1:35-51"}
        {Parasha = Parasha.``Vayera``; Reading = "John 2:1-12"}
        {Parasha = Parasha.``Chayei Sara``; Reading = "John 2:13-25"}
        {Parasha = Parasha.``Toldot``; Reading = "John 3:1-21"}
        {Parasha = Parasha.``Vayetzei``; Reading = "John 4:5-30"}
        {Parasha = Parasha.``Vayishlach``; Reading = "John 4:31-42"}
        {Parasha = Parasha.``Vayeshev``; Reading = "John 4:43-54"}
        {Parasha = Parasha.``Miketz``; Reading = "John 5:1-15"}
        {Parasha = Parasha.``Vayigash``; Reading = "John 5:16-29"}
        {Parasha = Parasha.``Vayechi``; Reading = "John 5:30-47"}
        {Parasha = Parasha.``Shemot``; Reading = "John 6:1-15"}
        {Parasha = Parasha.``Vaera``; Reading = "John 6:16-29"}
        {Parasha = Parasha.``Bo``; Reading = "John 6:30-51"}
        {Parasha = Parasha.``Beshalach``; Reading = "John 6:52-71"}
        {Parasha = Parasha.``Yitro``; Reading = "John 7:1-13"}
        {Parasha = Parasha.``Mishpatim``; Reading = "John 7:14-24"}
        {Parasha = Parasha.``Terumah``; Reading = "John 7:25-36"}
        {Parasha = Parasha.``Tetzaveh``; Reading = "John 7:37-52"}
        {Parasha = Parasha.``Ki Tisa``; Reading = "John 8:1-11"}
        {Parasha = Parasha.``Vayakhel``; Reading = "John 8:12-20"}
        {Parasha = Parasha.``Pekudei``; Reading = "John 8:21-30"}
        {Parasha = Parasha.``Vayakhel-Pekudei``; Reading = "John 8:12-30"}
        {Parasha = Parasha.``Vayikra``; Reading = ""}
        {Parasha = Parasha.``Tzav``; Reading = ""}
        {Parasha = Parasha.``Shmini``; Reading = ""}
        {Parasha = Parasha.``Tazria-Metzora``; Reading = ""}
        {Parasha = Parasha.``Tazria``; Reading = ""}
        {Parasha = Parasha.``Metzora``; Reading = ""}
        {Parasha = Parasha.``Achrei Mot-Kedoshim``; Reading = ""}
        {Parasha = Parasha.``Kedoshim``; Reading = ""}
        {Parasha = Parasha.``Achrei Mot``; Reading = ""}
        {Parasha = Parasha.``Emor``; Reading = ""}
        {Parasha = Parasha.``Behar``; Reading = ""}
        {Parasha = Parasha.``Bechukotai``; Reading = ""}
        {Parasha = Parasha.``Behar-Bechukotai``; Reading = ""}
        {Parasha = Parasha.``Bamidbar``; Reading = "John 11:38-57"}
        {Parasha = Parasha.``Nasso``; Reading = ""}
        {Parasha = Parasha.``Beha'alotcha``; Reading = ""}
        {Parasha = Parasha.``Sh'lach``; Reading = ""}
        {Parasha = Parasha.``Korach``; Reading = ""}
        {Parasha = Parasha.``Chukat``; Reading = ""}
        {Parasha = Parasha.``Balak``; Reading = ""}
        {Parasha = Parasha.``Pinchas``; Reading = ""}
        {Parasha = Parasha.``Matot``; Reading = ""}
        {Parasha = Parasha.``Masei``; Reading = ""}
        {Parasha = Parasha.``Matot-Masei``; Reading = ""}
        {Parasha = Parasha.``Devarim``; Reading = ""}
        {Parasha = Parasha.``Vaetchanan``; Reading = ""}
        {Parasha = Parasha.``Eikev``; Reading = ""}
        {Parasha = Parasha.``Re'eh``; Reading = ""}
        {Parasha = Parasha.``Shoftim``; Reading = ""}
        {Parasha = Parasha.``Ki Teitzei``; Reading = ""}
        {Parasha = Parasha.``Ki Tavo``; Reading = ""}
        {Parasha = Parasha.``Nitzavim``; Reading = ""}
        {Parasha = Parasha.``Vayeilech``; Reading = ""}
        {Parasha = Parasha.``Ha'Azinu``; Reading = ""}
        ]

    let HolidayReadings = [
        {Parasha = Parasha.``Sukkot I``; Reading = ""}
        {Parasha = Parasha.``Sukkot II``; Reading = ""}
        {Parasha = Parasha.``Yom Kippur``; Reading = ""}
        {Parasha = Parasha.``Rosh Hashana I``; Reading = ""}
        {Parasha = Parasha.``Rosh Hashana II``; Reading = ""}
        {Parasha = Parasha.``Shabbat Shuva``; Reading = ""}
        {Parasha = Parasha.``Rosh Hashana II``; Reading = ""}
        {Parasha = Parasha.``Shavuot I``; Reading = ""}
        ]

    let BesorotData (year: Year) =
        match year with
        | A -> CycleA
        | B -> CycleB
        | C -> CycleC
        
    type SpecialShabbat = Chanukah | Shekalim | Zachor | Parah | HaChodesh | HaGadol | Shuva

    let GetSpecialReadings special year = 
        match (special, year) with
        | (None,_) -> None
        | (Some SpecialShabbat.Chanukah), _ -> Some "John 10:22-42"
        | (Some SpecialShabbat.Shekalim), _ -> Some "Mark 12:41-44"
        | (_,_) -> None

    type WeeklyParasha = { Sedra: string; Shabbat: SpecialShabbat option}

    //type Readings =
    //    | year of Year
    //    | reading of list Reading

    let GetYear (calendarYear: int) = 
        match (calendarYear - 5771) % 3 with
        | 0 -> Year.A
        | 1 -> Year.B
        | _ -> Year.C

    let GetReading calendarYear weeklyParasha =
        let cycleYear = GetYear calendarYear
        let readings = BesorotData cycleYear

        let parasha = Option.get(Parasha.FromString weeklyParasha.Sedra) // TODO figure out how to handle this option

        let specialReading = GetSpecialReadings weeklyParasha.Shabbat cycleYear

        let reading = 
            match specialReading with
            | Some r -> Some { Parasha = parasha; Reading = r }
            | None -> (readings |> Seq.tryFind(fun i -> i.Parasha = parasha))

        reading

    let GetReadingBySedra calendarYear parasha specialShabbat =
        GetReading calendarYear { Sedra = parasha; Shabbat = specialShabbat }

        


