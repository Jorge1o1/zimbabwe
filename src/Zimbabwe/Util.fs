namespace Zimbabwe

module Util =
    let swap i j (arr: array<'a>) =
        let item = arr[i]
        arr[i] <- arr[j]
        arr[j] <- item

    let shuffle (arr: array<'a>) =
        let rnd = new System.Random()
        let ln = arr.Length

        [ 0 .. (ln - 2) ]
        |> Seq.iter (fun i -> swap i (rnd.Next(i, ln)) arr)

        arr

    let rec pairOff lst =
        match lst with
        | [] -> []
        | [ x ] -> []
        | x :: y :: tl -> (x, y) :: pairOff tl
