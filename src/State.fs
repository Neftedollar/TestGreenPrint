module App.State

open Elmish
open Elmish.Navigation
open Elmish.UrlParser
open Global
open Types
open Fable.Import
open Browser.Dom

let pageParser: Parser<Page->Page,Page> =
    oneOf [
        map About (s "about")
        map Counter (s "counter")
        map Button (s "button")
    ]

let urlUpdate (result : Page option) model =
    match result with
    | None ->
        console.error("Error parsing url")
        model, Navigation.modifyUrl (toHash model.CurrentPage)
    | Some page ->
        { model with CurrentPage = page }, []

let init result =
    let (counter, counterCmd) = Counter.State.init()
    let (button, homeCmd) = Button.State.init()
    let (model, cmd) =
        urlUpdate result
          { CurrentPage = Button
            Counter = counter
            Button = button }

    model, Cmd.batch [ cmd
                       Cmd.map CounterMsg counterCmd
                       Cmd.map ButtonMsg homeCmd ]

let update msg model =
    match msg with
    | CounterMsg msg ->
        let (counter, counterCmd) = Counter.State.update msg model.Counter
        { model with Counter = counter }, Cmd.map CounterMsg counterCmd
    | ButtonMsg msg ->
        let (button, homeCmd) = Button.State.update msg model.Button
        { model with Button = button }, Cmd.map ButtonMsg homeCmd
