namespace DailyProgrammer

open RedditSharp

type RedditGetter() =

    member this.GetDailyProgrammerChallenges() =
        let reddit = new Reddit()
        let dailyProgrammer = reddit.GetSubreddit(Subreddits.DailyProgrammer)
        let todaysPosts = dailyProgrammer.New |> Seq.filter (fun p -> p.IsSelfPost && p.Title.Contains("Challenge")) |> Seq.take 20
        let challenges = todaysPosts |> Seq.map (fun p -> ChallengeFactory.Create(p))
        challenges

