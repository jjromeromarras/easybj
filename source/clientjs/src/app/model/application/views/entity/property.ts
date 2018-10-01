import { BaseEntity } from "../../../common/baseentity";
import { Resource } from "../../../resources/resource";
import { PropertyDataType } from "./propertydatatype";
import { Format } from "../format/format";
import { Validator } from "../validator/validator";

export class Property extends BaseEntity {
        static readonly DefaultDecimalLength: number = 12;
        static readonly DefaultDecimalPrecision: number = 5;

        enumFullName: string;
        columnName: string;
        dataType: PropertyDataType;
        defaultValue: string;
        format: Format;
        help: string;
        isActiveProperty: boolean;
        isCustomField: boolean;
        isIndex: boolean;
        isPrimaryKey: boolean;
        isReadOnly: boolean;
        isRequiered: boolean;
        isVisible: boolean;
        lenght: number;
        precision: number;
        title: string;
        validator: Validator;
}