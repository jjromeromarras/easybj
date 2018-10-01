import {ViewFieldContainerControl} from './viewfieldcontainercontrol';
import {ViewControl} from './viewcontrol';


export class ViewPanel extends ViewFieldContainerControl {
    controls: Array<ViewControl>;
    colCount: number;
    rowCount: number;

    constructor(){
        super();
        this.controls = new Array<ViewControl>();
    }

}
