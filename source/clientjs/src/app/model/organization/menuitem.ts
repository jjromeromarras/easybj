import { Resource } from '../resources/resource'
import { MenuOrderType } from './menuordertype'
import { MenuBase } from './menubase';

export class MenuItem extends MenuBase {
    expressionCode: string;
    iconName: string;
    quickAccessKey: string;
    tooltipInternal: string;
    viewInternal: string;
    tooltip: Resource;
    menuOrderType: MenuOrderType;
    // TODO:
    // VIEW
    // IMAGE    

}