open DailyProgrammer

[<EntryPoint>]
let main argv = 
    let getter = new RedditGetter()
    let challenges = getter.GetDailyProgrammerChallenges() |> Seq.filter (fun c -> c.IsSome)
    0 // return an integer exit code
