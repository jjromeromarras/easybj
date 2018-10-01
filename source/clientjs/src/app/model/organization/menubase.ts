import { Resource } from '../resources/resource'
import { BaseEntity } from '../common/baseentity'

export class MenuBase extends BaseEntity {
    menuParentSeparator: string;
    parentMenu: MenuBase;
    sequence: number;
    text: Resource;
    textInternal: string;
    
    constructor() {
        super();
    }

}