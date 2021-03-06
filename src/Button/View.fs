module Button.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.BluePrint.Core
open Fable.React
open Fable.React.Props
open Types
open Fable.BluePrint.Icons


let chckBox dispatch name value =
  label
       []
       [ input
          [ Type "checkbox"
            OnChange (fun ev -> value |> not |> dispatch ) ]
         str name ]

let root model dispatch =
  div
    [ ]
    [ p
        [ ClassName "control" ]
        [ input
            [ ClassName "input"
              Type "text"
              Placeholder "Type your name"
              DefaultValue model.Text
              AutoFocus true
              OnChange (fun ev -> !!ev.target?value |> ChangeStr |> dispatch ) ] ]
      br [ ]
      chckBox (ActiveCh >> dispatch) "Active" model.Active
      br []
      chckBox (DisableCh >> dispatch) "Disabled" model.Disabled
      br []
      chckBox (LargeCh >> dispatch) "Large" model.Large
      br []
      chckBox (MinimalCh >> dispatch) "Minimal" model.Minimal
      br []
      chckBox (LoadingCh >> dispatch) "Loading" model.Loading
      br []
      Button.button
        [ Active model.Active
          IButtonProps.Disabled model.Disabled
          Intent model.Intent
          Large model.Large
          Loading model.Loading
          Minimal model.Minimal
          IButtonProps.Icon <| Some IconNames.Refresh ]
        [ if not model.IconOnly then yield str (sprintf "Hello %s" model.Text) ] ]
