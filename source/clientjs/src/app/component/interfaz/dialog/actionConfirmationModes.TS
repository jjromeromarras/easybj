export class ActionConfirmationModes {
    public static get None(): number { return 0; }
    public static get YesNo(): number { return 1; }
    public static get YesNoCancel(): number { return 2; }
    public static get Undo(): number { return 3; }
}

export class ActionConfirmationResponses {
    public static get None(): number { return 0; }
    public static get Yes(): number { return 1; }
    public static get No(): number { return 2; }
}