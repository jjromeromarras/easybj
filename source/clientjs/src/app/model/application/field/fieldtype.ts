import { BaseEntity } from '../../common/baseentity'
import { CheckDigit } from './checkdigit';
import { EditionLengthMode } from './editionlengthmode';
import { FillMode } from './fillmode';
import { Stereotype } from './stereotype';
import { TruncateType } from './truncatetype';

export class FieldType extends BaseEntity {

    checkDigit: CheckDigit;
    description: string;
    editionLengthMode: EditionLengthMode;
    entityStereotypeInternal: string;
    fillMode: FillMode;
    inputMask: string;
    length: number;
    stereotype: Stereotype;
    truncateType: TruncateType;
    checkinPropagationEnabled: boolean;

    constructor(){
        super();
        this.checkinPropagationEnabled = true;
    }

}