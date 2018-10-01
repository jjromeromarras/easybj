import { GroupActionToolbar } from "./groupactiontoolbar";


export class PanelToolbar {
    title: string;
    groups: Array<GroupActionToolbar>;    
    sequence: number;
    constructor(){
        this.groups = new Array<GroupActionToolbar>();
    }
}