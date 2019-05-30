module Global

type Page =
    | Button
    | Counter
    | About

let toHash page =
    match page with
    | About -> "#about"
    | Counter -> "#counter"
    | Button -> "#button"
