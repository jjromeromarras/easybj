import { ResourceLanguage } from './resourcelanguage'
import { BaseEntity } from '../common/baseentity'

export class Resource extends BaseEntity {
    key: string;
    resourceTranslations: Array<ResourceLanguage>;

    constructor() {
        super();
        this.resourceTranslations = new Array<ResourceLanguage>();
    }
}