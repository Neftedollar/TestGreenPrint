module Button.State
open Fable.BluePrint.Core
open Elmish
open Types

let init () : Model * Cmd<Msg> =
  {Text = ""
   Active =    false
   Disabled =  false
   IconOnly =  false
   Intent =    Intent.NONE
   Loading =   false
   Large =     false
   Minimal =   false
   }, []

let update msg model : Model * Cmd<Msg> =
    match msg with
    | ChangeStr str -> {model with Text = str }, []
    | ActiveCh b -> { model with Active = b }, []
    | DisableCh b -> { model with Disabled = b }, []
    | IconOnlyCh b -> { model with IconOnly = b }, []
    | NewIntent b -> { model with Intent = b }, []
    | LoadingCh b -> { model with Loading = b }, []
    | LargeCh b -> { model with Large = b }, []
    | MinimalCh b -> { model with Minimal = b }, []
