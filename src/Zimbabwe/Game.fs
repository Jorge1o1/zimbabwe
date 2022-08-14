namespace Zimbabwe

module Game =
    open Land
    open Player

    type Phase =
        | Setup
        | MonumentSelection
        | Bidding
        | Final

    type Game =
        { Phase: Phase
          Board: LandNode list
          Players: Player list
          RemainingPlayers: PlayerName list }

    type Move = PlaceMonument of (int * int)

    let rec parseMoveFromInput () =
        let parts = System.Console.ReadLine().Split(' ')

        let coords =
            parts[1 .. parts.Length]
            |> Array.toList
            |> List.map System.Int32.Parse
            |> Util.pairOff

        match parts[0] with
        | "PM" -> PlaceMonument(List.head coords)
        | _ ->
            printfn "Unable to parse input into move, try again"
            parseMoveFromInput ()

    let isMoveLegal game move =
        match game.Phase, move with
        | MonumentSelection, PlaceMonument x -> true
        | _ -> false

    let rec prompt game pname =
        printfn "Prompting %A to make a move" pname
        let player = findByName game.Players pname

        match player.Type with
        | Human ->
            let move = parseMoveFromInput ()

            match isMoveLegal game move with
            | true -> move
            | false ->
                printfn "Move is illegal, try again"
                prompt game pname

    let apply game move = game

    let setup game =
        // TODO: shuffle cards, etc.
        let pn =
            game.Players
            |> List.map (fun p -> p.Name)
            |> List.toArray
            |> Util.shuffle
            |> Array.toList

        { game with
            RemainingPlayers = pn
            Phase = MonumentSelection }

    let rec loop game =
        match game.Phase with
        | Setup ->
            printfn "Entering Setup Phase"

            loop (setup game)
        | MonumentSelection ->
            printfn "Entering Monument Selection Phase"

            match game.RemainingPlayers with
            | currPl :: tl ->
                let move = prompt game currPl
                let nextState = apply game move
                loop { nextState with RemainingPlayers = tl }
            | [] -> loop { game with Phase = Bidding }
        | Bidding ->
            printfn "Entering Bidding Phase"
            loop game
        | Final ->
            let winner = List.maxBy (fun p -> p.VictoryPoints) game.Players
            (winner.Name, winner.VictoryPoints)
