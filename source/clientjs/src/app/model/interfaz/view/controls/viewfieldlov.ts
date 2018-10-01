import { Lov } from './lov';
import { Property } from '../../../application/views/entity/property';

export class ViewFieldLov {
    // WebApi Model
    guid: string;
    dependantProperty: Property;
    dependantViewFieldLOV: ViewFieldLov;
    displayProperty: Property;
    listOfValues: Array<Lov>;
    lovType: string;
    rowLimit: number;
    showProperties: Array<Property>;
    sqlOrderBy: string;
    sqlWhere: string;
    valueProperty: Property;
}