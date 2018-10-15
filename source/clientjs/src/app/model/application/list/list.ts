import { BaseEntity } from '../../common/baseentity';
import { BindData } from '../objstr';

export class List extends BaseEntity {

    description: BindData;

    constructor(){
        super();
        this.description = new BindData();
    }
}