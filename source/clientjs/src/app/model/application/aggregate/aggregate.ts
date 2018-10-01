import { BaseEntity } from '../../common/baseentity'
import { AggregateProperty } from './aggregateproperty';


export class Aggregate extends BaseEntity {
    
    applicationName: string;
    assemblyFullName: string;
    description: string;
    fromMetadata: boolean;
    fullName: string;
    internalName: string;
    obsolete: boolean;
    obsoleteMessage: string;
    properties: Array<AggregateProperty>;
    tableName: string;

    constructor() {
        super();
        this.properties = new Array<AggregateProperty>();
    }
}