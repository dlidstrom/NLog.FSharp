namespace NLog.FSharp

open System

type ILogger =
    /// Writes the diagnostic message at the `Trace` level.
    abstract Trace : fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Trace` level.
    abstract TraceException : e : Exception -> fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Debug` level.
    abstract Debug : fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Debug` level.
    abstract DebugException : e : Exception -> fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Info` level.
    abstract Info : fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Info` level.
    abstract InfoException : e : Exception -> fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Warn` level.
    abstract Warn : fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Warn` level.
    abstract WarnException : e : Exception -> fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Error` level.
    abstract Error : fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Error` level.
    abstract ErrorException : e : Exception -> fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Fatal` level.
    abstract Fatal : fmt : Printf.StringFormat<'a, unit> -> 'a

    /// Writes the diagnostic message at the `Fatal` level.
    abstract FatalException : e : Exception -> fmt : Printf.StringFormat<'a, unit> -> 'a

type Logger(logger : NLog.ILogger) =

    new(name : string) =
        Logger(NLog.LogManager.GetLogger(name))

#if NETSTANDARD1_6
#else
    new() =
        let callerType =
            Diagnostics.StackTrace(1, false)
                .GetFrames().[0]
                .GetMethod()
                .DeclaringType
        Logger(callerType.Name)
#endif

    /// Writes the diagnostic message at the `Trace` level.
    member _.Trace fmt =
        Printf.kprintf (fun s -> logger.Trace(s)) fmt

    /// Writes the diagnostic message at the `Trace` level.
    member _.TraceException (e : Exception) fmt =
        Printf.kprintf (fun s -> logger.Trace(e, s)) fmt

    /// Writes the diagnostic message at the `Debug` level.
    member _.Debug fmt =
        Printf.kprintf (fun s -> logger.Debug(s)) fmt

    /// Writes the diagnostic message at the `Debug` level.
    member _.DebugException (e : Exception) fmt =
        Printf.kprintf (fun s -> logger.Debug(e, s)) fmt

    /// Writes the diagnostic message at the `Info` level.
    member _.Info fmt =
        Printf.kprintf (fun s -> logger.Info(s)) fmt

    /// Writes the diagnostic message at the `Info` level.
    member _.InfoException (e : Exception) fmt =
        Printf.kprintf (fun s -> logger.Info(e, s)) fmt

    /// Writes the diagnostic message at the `Warn` level.
    member _.Warn fmt =
        Printf.kprintf (fun s -> logger.Warn(s)) fmt

    /// Writes the diagnostic message at the `Warn` level.
    member _.WarnException (e : Exception) fmt =
        Printf.kprintf (fun s -> logger.Warn(e, s)) fmt

    /// Writes the diagnostic message at the `Error` level.
    member _.Error fmt =
        Printf.kprintf (fun s -> logger.Error(s)) fmt

    /// Writes the diagnostic message at the `Error` level.
    member _.ErrorException (e : Exception) fmt =
        Printf.kprintf (fun s -> logger.Error(e, s)) fmt

    /// Writes the diagnostic message at the `Fatal` level.
    member _.Fatal fmt =
        Printf.kprintf (fun s -> logger.Fatal(s)) fmt

    /// Writes the diagnostic message at the `Fatal` level.
    member _.FatalException (e : Exception) fmt =
        Printf.kprintf (fun s -> logger.Fatal(e, s)) fmt

    interface ILogger with
        member this.Trace fmt =
            this.Trace fmt
        member this.TraceException e fmt =
            this.TraceException e fmt
        member this.Debug fmt =
            this.Debug fmt
        member this.DebugException e fmt =
            this.DebugException e fmt
        member this.Info fmt =
            this.Info fmt
        member this.InfoException e fmt =
            this.InfoException e fmt
        member this.Warn fmt =
            this.Warn fmt
        member this.WarnException e fmt =
            this.WarnException e fmt
        member this.Error fmt =
            this.Error fmt
        member this.ErrorException e fmt =
            this.ErrorException e fmt
        member this.Fatal fmt =
            this.Fatal fmt
        member this.FatalException e fmt =
            this.FatalException e fmt
