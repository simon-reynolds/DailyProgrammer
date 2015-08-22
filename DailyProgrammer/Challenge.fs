namespace DailyProgrammer

open System

type Difficulty = Easy | Intermediate | Hard | EasyIntermediate | IntermediateHard | Unknown

type Challenge(number : int, difficulty : Difficulty, datePosted : DateTimeOffset, title : string, content : string) = 
    member this.Number = number
    member this.Difficulty = difficulty
    member this.DatePosted = datePosted
    member this.Title = title
    member this.Content = content

