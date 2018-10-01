import { BaseEntity } from '../../common/baseentity'


export class Subscription extends BaseEntity {
    applicationIdForEventSubscription: string;
    description: string;
    hasAnotherApplicationEvents: boolean;
    isActive: boolean;
    // TODO FALTA
}