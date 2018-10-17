import { ModelHelper } from '../../utils/modelhelper';
import { CheckStatus } from './checkstatus';
import { UsableAsEntityStereotype } from './usableasentitystereotype';
import { BindData } from '../application/objstr';


export class BaseEntity {
    guid: string;
    checkStatus: CheckStatus;
    description: BindData;
    name: BindData;
    createDate: Date;
    createdBy: string;
    updateDate: Date;
    updatedBy: string;
    lockedBy: string;
    lockedDate: Date;
    version: string;
    applicationsource: string;
    usableAsEntityStereotype: UsableAsEntityStereotype;

    constructor() {
        this.checkStatus = CheckStatus.New;
        this.usableAsEntityStereotype = new UsableAsEntityStereotype();

        this.guid = ModelHelper.Guid();
        this.createDate = new Date(Date.now());
        this.name = new BindData();
        this.description = new BindData();

    }
}