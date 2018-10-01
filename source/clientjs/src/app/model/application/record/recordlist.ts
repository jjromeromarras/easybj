import { BaseEntity } from '../../common/baseentity'
import { Config } from '../../../services/config.service'
import { Record } from './record'

export class RecordList extends BaseEntity {
    description: string;
    files: number;
    record: Record;
}