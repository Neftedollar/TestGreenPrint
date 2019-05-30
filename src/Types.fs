module App.Types

open Global

type Msg =
    | CounterMsg of Counter.Types.Msg
    | ButtonMsg of Button.Types.Msg

type Model =
    { CurrentPage: Page
      Counter: Counter.Types.Model
      Button: Button.Types.Model }
