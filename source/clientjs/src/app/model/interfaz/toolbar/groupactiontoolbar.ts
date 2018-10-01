import { ActionToolbar } from "./actiontoolbar";

export class GroupActionToolbar {
    title: string;
    actions: Array<ActionToolbar>;    
    sequence: number;
    
    constructor(){
        this.actions = new Array<ActionToolbar>();
    }
}