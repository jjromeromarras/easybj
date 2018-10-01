import { ViewControl } from './viewcontrol';
import { ViewFieldLov } from './viewfieldlov';
import { BindData } from '../../../application/objstr';

export class ViewField extends ViewControl {
        allowEdit: boolean;
        viewFieldType: string;
        isRequired: boolean;
        hasError: boolean;
        textError: string;
        dataobj: any;
        property: string;
        viewName: string;
        allowSearch: boolean;
        showValue: string;
        viewFieldLOV: ViewFieldLov;

        get data(): any {
                if (this.dataobj == undefined) {
                        this.dataobj = new BindData();
                }
                return this.dataobj.value;
        }

        set data(value: any) {
                if (this.dataobj == undefined) {
                        this.dataobj = new BindData();
                }
                this.dataobj.value = value;
        }
        getData = () => {
                return this.dataobj[this.property];
        };

        setData = (newData: any) => {
                this.dataobj.value = newData;
        };
        getShowValue = () => {
                return this.showValue;
        };
        setShowValue = (newShowValue: any) => {
                this.showValue = newShowValue;
        };

        constructor() {
                super();
                this.currentVisible = true;
                this.hasError = false;
                this.isRequired = false;
                this.allowEdit = true;
                this.allowSearch = false;
        }

}