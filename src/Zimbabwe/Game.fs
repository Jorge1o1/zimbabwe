namespace Zimbabwe

module Game =
    open Zimbabwe.Land

    type Phase =
    | Setup
    | Final 

    type Game = {
        Phase: Phase
        Land: LandNode list
    }

    let rec loop game =
        match game.Phase with
        | Setup -> loop game
        | Final -> ("Jorge", 100)