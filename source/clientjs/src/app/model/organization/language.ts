import { BaseEntity } from '../common/baseentity'

export class Language extends BaseEntity {
    changedDefaultLanguage: boolean;
    countryCode: string;
    isActive: boolean;
    isDefaultLanguage: boolean;
    rightToLeft: boolean;

    constructor() {
        super();
        this.isActive = true;

    }
}