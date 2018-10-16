import { BaseEntity } from '../../common/baseentity'
import { Stereotype } from '../field/stereotype';

export class WorkflowAttribute extends BaseEntity {
    initialValue: string;
    length: number;
    persist: boolean;
    stereotype: Stereotype;

    constructor(){
        super();      
    }
}