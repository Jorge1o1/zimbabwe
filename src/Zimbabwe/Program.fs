// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Zimbabwe
open Zimbabwe.Game
open Zimbabwe.Player

[<EntryPoint>]
let main argv =
    // let config = {
    //     StartingChoices = Week35.startingChoices
    //     BonusCardChoices = Week35.bonusCardChoices
    //     BirdfeederSeries = Week35.birdfeeder
    // }
    // // let player1 = { HumanPlayer.Name = "Jorge"; Board = Board.empty; Hand = []; Supply = []; BonusCards = [] }
    // let player1 = { RandomPlayer.Name = "RND"; RNG = Random(123); State = PlayerState.empty}
    // let player2 = { AutomaPlayer.Name = "QT-1"; Moves = Week35.automaMoves}
    let player1 =
        { Player.Name = Green
          Type = Human
          Monuments = []
          VictoryPoints = 0
          VictoryRequirement = 20 }

    let player2 =
        { Player.Name = Red
          Type = Human
          Monuments = []
          VictoryPoints = 0
          VictoryRequirement = 20 }

    let players = [ player1; player2 ]

    let game =
        { Phase = Setup
          Board = []
          Players = players
          RemainingPlayers = List.map (fun p -> p.Name) players }

    let lnd = Land.landArrToLandGraph Data.HomeTile
    let (winner, score) = loop game
    printfn "Congratulations %A! You had %i points!" winner score
    1
