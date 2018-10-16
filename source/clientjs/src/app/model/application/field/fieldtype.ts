import { BaseEntity } from '../../common/baseentity'
import { Stereotype } from './stereotype';
import { BindData } from '../objstr';

export class FieldType extends BaseEntity {

    entityStereotypeInternal: BindData;
    stereotype: Stereotype;

    constructor(){
        super();
        this.entityStereotypeInternal = new BindData();
    }

}