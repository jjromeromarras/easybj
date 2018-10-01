import { BaseEntity } from '../../common/baseentity'
import { EventPropertyDataType } from './eventpropertydatatype';



export class EventProperty extends BaseEntity {
    dataType: EventPropertyDataType;
    description: string;

    constructor() {
        super();
        this.dataType = EventPropertyDataType.Boolean;
    }
}