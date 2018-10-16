import { BaseEntity } from '../../common/baseentity'
import { AggregatePropertyDataType } from './aggregatepropertydatatype';


export class AggregateProperty extends BaseEntity {
    enumFullName: string;
    recordName: string;
    dataType: AggregatePropertyDataType;
    obsolete: boolean;
    obsoleteMessage: string;
    originalName: string;
    recordAggregateName: string;
    recordPropertiesMetadata: Array<AggregatePropertyDataType>;

    public constructor() {
        super();
        this.recordPropertiesMetadata = new Array<AggregatePropertyDataType>();
    }
}