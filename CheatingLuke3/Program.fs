module Calendar03

//PROBLEM
//Tenk deg et rutenett med 10x10 ruter, som kan være hvite eller sorte. Koordinatene telles fra 0, så vi har koordinater 0-9 langs X og Y-aksene. Alle rutene har et nummer, som er definert som X*10+Y. Så rute (5,7) har nummer 57, og rute (9,9) har nummer 99.

//I begynnelsen er alle rutene hvite. I posisjon (0,0) står en sjakk-springer (også kjent som hest).

//Brikken flytter etter følgende regler hver runde:

//    Undersøk rutene springeren kan flytte til (etter vanlige sjakk-regler uten å forlate rutenettet). Flytt til den av disse rutene som har lavest nummer og som har samme farge som ruten springeren står på. Hvis ingen av disse rutene har samme farge, flytt til den ruten som har høyest nummer.
//    Etter at springeren har flyttet, skift farge på ruten som springeren nettopp forlot.

//Hvor mange av rutene er sorte når springeren har flyttet 200 ganger? (Ja, fargen på ruten springeren forlot den siste gangen skal skiftes før du teller.)

let possibleMoves x y : (int*int) list= 
    let p0 = (x+2, y+1)
    let p1 = (x+1, y+2)
    let p2 = (x-2, y+1)
    let p3 = (x-1, y+2)
    let p4 = (x+2, y-1)
    let p5 = (x+1, y-2)
    let p6 = (x-2, y-1)
    let p7 = (x-1, y-2)
    let a = [p0;p1;p2;p3;p4;p5;p6;p7]
    a |> List.filter (fun (x', y') -> x' <= 9 && x' >= 0 && y' >= 0 && y' <= 9)


let ascending list =
    list |> List.sortBy (fun (x,y) -> (10*x) + y)

let descending list =
    list |> List.sortBy (fun (x,y) -> ((10*x) + y) * (-1))

let initBoard = 
    [0 .. 99] |> List.map (fun _ -> 1)

let initPosition = (0,0)

let getColor (x,y) (board: int list) = 
    let i = 10*x + y
    board.Item(i)

let findNextMove (possibilities:(int*int) list) board currentColor =
    let sameColorPossibilities = possibilities |> List.filter (fun (x,y) -> (getColor (x,y) board) = currentColor ) |> ascending
    let oppositeColorPossibilities = possibilities |> List.filter (fun (x,y) -> (getColor (x,y) board) <> currentColor ) |> descending

    match sameColorPossibilities.Length with
    | 0 -> 
        oppositeColorPossibilities.[0]        
    | _ ->
        sameColorPossibilities.[0]

let switch x =
    match x with
    | 1 -> 0
    | _ -> 1

let updateBoard (board: int list) (x,y) =
    let index = (10*x) + y
    board |> List.mapi (fun i x -> if index = i then switch x else x )

let move1 (x,y) board =
    let currentColor = getColor (x,y) board
    let possibilities = possibleMoves x y
    let (x', y') = findNextMove possibilities board currentColor
    let board' = updateBoard board (x,y)
    ((x',y'), board')

let rec moveN position board n =
    match n with
    | 0 -> (position, board)
    | _ ->
        let ((x', y'), board') = move1 position board
        moveN (x',y') board' (n-1)

let getSolution =
    let board = initBoard
    let position = initPosition
    let (_, board') = moveN position board 200

    let sum = 100 - List.sum board'

    sprintf "%i" sum
    