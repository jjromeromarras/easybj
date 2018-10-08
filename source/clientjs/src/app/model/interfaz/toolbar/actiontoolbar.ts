export class ActionToolbar {
    title: string;
    image: string;
    sequence: number;

    executeAction: (params: any) => void;
    visibleAction: (params: any) => boolean;

    constructor() {
    }
}