import { BaseEntity } from "../../../common/baseentity";
import { Resource } from "../../../resources/resource";
import { Property } from "./property";


export class Entity extends BaseEntity {
    isTemplate: boolean;
    MaxLengthNameDatawarehouse: number = 28;
    description: string;
    fromMetadata: boolean;
    isDataWarehouse: boolean;
    pluralName: Resource;
    properties: Array<Property>;
    singularName: Resource;
    tableName: string;
    checkinPropagationEnabled: boolean;

    constructor() {
        super();
        this.fromMetadata = false;
        this.checkinPropagationEnabled = true;
    }
}