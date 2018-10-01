import { BaseEntity } from "../../../common/baseentity";
import { Resource } from "../../../resources/resource";
import { FormatDataType } from "./formatdatatype";

export class Format extends BaseEntity {
    description: string;
    formatDataType: FormatDataType;
    formatString: string;
}