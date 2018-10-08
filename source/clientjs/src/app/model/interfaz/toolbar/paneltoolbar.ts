import { GroupActionToolbar } from './groupactiontoolbar';
import { eWorkAreaType } from '../enums/eworkareatype';


export class PanelToolbar {
    title: string;
    groups: Array<GroupActionToolbar>;
    sequence: number;
    type: any;
    constructor() {
        this.type = eWorkAreaType.None;
        this.groups = new Array<GroupActionToolbar>();
    }
}
