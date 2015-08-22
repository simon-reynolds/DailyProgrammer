namespace DailyProgrammer
open FSharp.Text.RegexProvider
open RedditSharp.Things

type TitleRegex = Regex< @"\[[\d\-]+\] Challenge \#(?<Number>\d{1,5}) \[(?<Difficulty>\w+/?\w+)\] (?<Title>.+)">

type ChallengeFactory() =

    static member private ParseDifficulty(difficulty : string) =
        match difficulty.ToUpperInvariant() with
        | "EASY" -> Difficulty.Easy
        | "INTERMEDIATE" -> Difficulty.Intermediate
        | "HARD" -> Difficulty.Hard
        | "EASY/INTERMEDIATE" -> Difficulty.EasyIntermediate
        | "INTERMEDIATE/HARD" -> Difficulty.IntermediateHard
        | _ -> Difficulty.Unknown
        
    static member Create(post : Post) =
        let regexMatch = TitleRegex().Match(post.Title)

        if not regexMatch.Success then None
        else 
        let challengeNumber = System.Int32.Parse(regexMatch.Number.Value)
        let difficulty = ChallengeFactory.ParseDifficulty(regexMatch.Difficulty.Value)
        let datePosted = new System.DateTimeOffset(post.CreatedUTC)
        let title = regexMatch.Title.Value
        let content = post.SelfText

        let challenge = Challenge(challengeNumber, difficulty, datePosted, title, content)
        Some challenge
    