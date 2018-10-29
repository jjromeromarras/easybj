export enum eTraceLevel {
    Debug = 0,
    Info = 1,
    Warn = 2,
    Error = 3
}

/** Const access from html */
export const eTraceLevelHtml = Object.freeze({
    Debug: eTraceLevel.Debug,
    Info: eTraceLevel.Info,
    Warn: eTraceLevel.Warn,
    Error: eTraceLevel.Error
});