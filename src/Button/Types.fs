module Button.Types
open Fable.BluePrint.Core

type Model = {
    Active  : bool
    Disabled: bool
    IconOnly: bool
    Intent  : Intent
    Loading : bool
    Large   : bool
    Minimal : bool
    // Wiggling: bool
    Text    : string
}

type Msg =
    | ChangeStr of string
    | ActiveCh of bool
    | DisableCh of bool
    | IconOnlyCh of bool
    | NewIntent of Intent
    | LoadingCh of bool
    | LargeCh of bool
    | MinimalCh of bool
