namespace Zimbabwe

open Zimbabwe.Monument

module Player =
    type PlayerName =
        | Green
        | Red
        | Black
        | White
        | Yellow

    type PlayerType = | Human

    type Player =
        { Name: PlayerName
          Type: PlayerType
          Monuments: Monument list
          VictoryPoints: int
          VictoryRequirement: int }

    let findByName plst name = List.find (fun p -> p.Name = name) plst
