namespace Zimbabwe

module Land =
    type LandType =
        | Empty
        | Water
        | Wood
        | Clay
        | Ivory
        | Diamond
        | StartingPoint
        | Craftsman
        | Monument


    type LandNode = { X: int; Y: int; LandType: LandType }

    let parseLandFromString s =
        match s with
        | "E" -> Empty
        | "W" -> Water
        | "T" -> Wood
        | "C" -> Clay
        | "I" -> Ivory
        | "D" -> Diamond
        | "S" -> StartingPoint
        | "X" -> Craftsman
        | "M" -> Monument
        | _ -> raise (System.ArgumentException(s))

    let landArrToLandGraph (arr2d: string [,]) =
        Array2D.mapi
            (fun i j x ->
                { X = i
                  Y = j
                  LandType = parseLandFromString x })
            arr2d
