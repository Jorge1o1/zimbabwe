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
          Players: Player list }

    let rec loop game =
        match game.Phase with
        | Setup ->
            // TODO: shuffle players, shuffle cards, etc.
            loop game
        | MonumentSelection ->
            let allMonumentsPlaced =
                game.Players
                |> List.map (fun p -> not p.Monuments.IsEmpty)
                |> (List.fold (&&) true)

            match allMonumentsPlaced with
            | true -> loop { game with Phase = Bidding }
            | false -> loop game
        | Bidding -> loop game
        | Final ->
            let winner = List.maxBy (fun p -> p.VictoryPoints) game.Players
            (winner.Name, winner.VictoryPoints)
