import { BaseEntity } from '../common/baseentity'
import { BindData } from '../application/objstr';

export class Language extends BaseEntity {
    changedDefaultLanguage: BindData;
    countryCode: BindData;
    isActive: BindData;
    isDefaultLanguage: BindData;
    rightToLeft: BindData;

    constructor() {
        super();
        this.changedDefaultLanguage = new BindData();
        this.countryCode = new BindData();
        this.isActive = new BindData();
        this.rightToLeft = new BindData();
        this.isDefaultLanguage = new BindData();
        this.isActive.value = true;
        this.isDefaultLanguage.value = false;
        this.rightToLeft.value = false;
    }
}