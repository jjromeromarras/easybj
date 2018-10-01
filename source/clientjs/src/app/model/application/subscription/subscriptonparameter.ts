import { BaseEntity } from '../../common/baseentity'
import { EventProperty } from '../event/eventproperty';
import { WorkflowAttribute } from '../workflow/worflowattribute';


export class SubscriptionParameter extends BaseEntity {
    eventProperty: EventProperty;
    processAttribute: WorkflowAttribute;
    eventPropertyInternal: string;
    processAttributeInternal: string;
}