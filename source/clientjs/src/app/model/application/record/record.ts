import { BaseEntity } from '../../common/baseentity';
import { FieldRecord } from '../field/fieldrecord';
import { RecordType } from './recordtype';

export class Record extends BaseEntity {

    autoUpdateLength: boolean;
    fieldRecords: Array<FieldRecord>;
    overridenVersionId: string;
    recordType: RecordType;
    separator: string;

    constructor() {
        super();
        this.fieldRecords = new Array<FieldRecord>();
    }

}