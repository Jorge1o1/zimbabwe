namespace Zimbabwe

open Zimbabwe.Monument

module Player =
    type Player =
        { Name: string
          Monuments: Monument list
          VictoryPoints: int
          VictoryRequirement: int }
