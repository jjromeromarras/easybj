import {ViewControl} from './viewcontrol';
import {ViewField} from './viewfield';

export class ViewFieldContainerControl extends ViewControl {
    viewFields: Array<ViewField>;

    constructor(){
        super();
        this.viewFields = new Array<ViewField>();
    }
}