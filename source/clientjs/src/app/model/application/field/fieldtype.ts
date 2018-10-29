import { BaseEntity } from '../../common/baseentity';
import { BindData } from '../objstr';

export class FieldType extends BaseEntity {

    entityStereotypeInternal: BindData;
    stereotype: BindData;

    constructor() {
        super();
        this.entityStereotypeInternal = new BindData();
        this.stereotype = new BindData();
    }

}