import { BaseEntity } from '../common/baseentity'
import { Action } from '../application/views/action';
import { RFMenuItem } from './rfmenuitem';
import { ViewGroup } from '../application/views/viewgroups';

export class SecGroup extends BaseEntity {

    description: string;
    emailAddress: string;
    actions: Array<Action>;
    rfMenuItems: Array<RFMenuItem>;
    viewGroups: Array<ViewGroup>;
    
    constructor() {
        super();
        this.actions = new Array<Action>();
        this.rfMenuItems = new Array<RFMenuItem>();
        this.viewGroups = new Array<ViewGroup>();
    }

}