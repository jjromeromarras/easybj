/** Modes of ViewList and ViewEdit */
export enum eViewModes {
    Read = 0,
    Edit = 1,
    New = 2,
};

/** Const access from html */
export const eViewModesHtml = Object.freeze({
    Read: eViewModes.Read,
    Edit: eViewModes.Edit,
    New: eViewModes.New,
});