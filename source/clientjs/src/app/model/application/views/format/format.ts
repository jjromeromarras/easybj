import { BaseEntity } from "../../../common/baseentity";
import { FormatDataType } from "./formatdatatype";

export class Format extends BaseEntity {
    formatDataType: FormatDataType;
    formatString: string;
}