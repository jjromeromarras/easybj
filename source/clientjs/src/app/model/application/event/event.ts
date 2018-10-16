import { BaseEntity } from '../../common/baseentity'
import { EventProperty } from './eventproperty';

export class Event extends BaseEntity {
    isTemplate: boolean;
    fromMetadata: boolean;
    internalName: string;
    isPublic: boolean;
    properties: Array<EventProperty>;
    versionId: string;   
    checkinPropagationEnabled: boolean;

    constructor(){
        super();
        this.checkinPropagationEnabled = true;
    }
}