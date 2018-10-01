import { BaseEntity } from '../../common/baseentity'
import { Stereotype } from '../field/stereotype';

export class WorkflowAttribute extends BaseEntity {
    description: string;
    initialValue: string;
    length: number;
    persist: boolean;
    stereotype: Stereotype;

    constructor(){
        super();      
    }
}