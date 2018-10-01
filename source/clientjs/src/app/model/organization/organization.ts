import { MenuItem } from './menuitem'
import { Resource } from '../resources/resource'
import { BaseEntity } from '../common/baseentity'
import { SecGroup } from './secgroup';

export class Organization extends BaseEntity {
    description: string;
    isActive: boolean;
    onlineMode: boolean;
    menuItems: Array<MenuItem>;
    resources: Array<Resource>;
    secGroups: Array<SecGroup>;
    // TODO: Falta imagen 

    constructor() {
        super();
        this.resources = new Array<Resource>();
        this.menuItems = new Array<MenuItem>();
        this.secGroups = new Array<SecGroup>();
    }
}