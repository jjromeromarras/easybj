import { BaseEntity } from '../../common/baseentity'
import { FieldType } from './fieldtype';

export class FieldRecord extends BaseEntity {
    end: number;
    fieldType: FieldType;
    format: string;
    isChangingLength: boolean;
    length: number;
    start: number;
}