import { BaseEntity } from '../../common/baseentity'
import { ConfirmationModes } from './confirmationmodes'
import { Resource } from '../../resources/resource'


export class Action extends BaseEntity {
    confirmationCode: string;
    confirmationMode: ConfirmationModes;
    confirmationText: Resource;
    //TODO IMAGEN
    imageName: string;
    quickAccessKey: string;
    sequence: number;
    title: Resource;
    toolTip: Resource;
    visible: boolean;
    visibleCondition: boolean;
    visibleMultiRowSelected: boolean;
    visibleNoRowSelected: boolean;
    visibleOneRowSelected: boolean;

    constructor(){
        super();
        this.visible = this.visibleMultiRowSelected = this.visibleNoRowSelected = this.visibleOneRowSelected = true;
    }
}