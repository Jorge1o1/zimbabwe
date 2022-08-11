// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open Zimbabwe
open Zimbabwe.Game
open Zimbabwe

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
    let game =
        { Phase = Setup
          Board = []
          Players = [] }

    let lnd = Land.landArrToLandGraph Data.MidString
    let (winner, score) = loop game
    printfn "Congratulations %s! You had %i points!" winner score
    1
