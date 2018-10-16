import { BaseEntity } from '../../common/baseentity'
import { Config } from '../../../services/config.service'
import { Record } from './record'

export class RecordList extends BaseEntity {
    files: number;
    record: Record;
}