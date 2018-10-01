import { ModelHelper } from '../../utils/modelhelper'
import { CheckStatus } from './checkstatus'
import { UsableAsEntityStereotype } from './usableasentitystereotype';
import { InheritanceType } from './Inheritancetype';
import { BindData } from '../application/objstr';


export class BaseEntity {
    guid: string;
    checkStatus: CheckStatus;
    name: BindData;
    createDate: Date;
    createdBy: string;
    updateDate: Date;
    updatedBy: string;
    lockedBy: string;
    lockedDate: Date;
    version: string;
    usableAsEntityStereotype: UsableAsEntityStereotype;

    constructor() {
        this.checkStatus = CheckStatus.New;
        this.usableAsEntityStereotype = new UsableAsEntityStereotype();
        this.usableAsEntityStereotype.inheritanceType = InheritanceType.NoInheritance;
        
        this.guid  = ModelHelper.Guid();
        this.createDate = new Date(Date.now());
        this.name = new BindData();

    }
}