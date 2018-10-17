import { Component, Input, ViewChild, ChangeDetectorRef, OnInit, SimpleChange } from '@angular/core';
import { DxSelectBoxComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';
import { ViewField } from '../../../../../model/interfaz/view/controls/viewfield';
import { eViewModes, eViewModesHtml } from '../../../../../model/interfaz/enums/eviewmodes';
import { eViewFieldTypes } from '../../../../../model/interfaz/enums/eviewfieldtypes';
import { Config } from '../../../../../services/config.service';
@Component({

    selector: 'app-viewfieldselectbox',
    templateUrl: './viewfieldselectbox.component.html'
})

export class ViewFieldSelectBoxComponent implements OnInit {



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @ViewChild('selectBox') selectBox: DxSelectBoxComponent;
    @Input() viewField: ViewField;
    @Input() readyMode: Boolean;
    @Input() viewMode: eViewModes;
    @Input() isVisible: boolean;
    @Input() isReq: boolean;
    @Input() containerName: string;
    @Input() notRenderInlineButton: boolean;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    eViewModes = eViewModesHtml;        // Access to enumeration from html
    eViewFieldTypes = eViewFieldTypes;  // Access to enumeration from html
    public showProperties: string[] = [];
    public columnsProperties: string[] = [];
    public columnwidthclass = 'width-100';
    public displayExpressionLOV: string;
    public valueExpressionLOV: string;
    public dataSource: any = undefined;
    public searchEnabled: boolean;
    public renderOnCreate = false;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private displayValueFlag: boolean;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config) {
        this.searchEnabled = false;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NG METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ngOnInit() {
      
        if (this.viewField != null && this.viewField.viewFieldLOV != null) {
            this.displayValueFlag = this.viewField.viewFieldLOV != undefined &&
                (this.viewField.viewFieldLOV.valueProperty != undefined &&
                    this.viewField.viewFieldLOV.displayProperty != undefined &&
                    this.viewField.viewFieldLOV.valueProperty.name != this.viewField.viewFieldLOV.displayProperty.name);
            this.viewField.hasError = false;
            this.viewField.textError = '';
            this.showProperties = [];
            this.columnsProperties = [];
            if (this.viewField.viewFieldType != eViewFieldTypes.DropDownList) {
                if (this.viewField.viewFieldLOV.displayProperty != null &&
                    this.viewField.viewFieldLOV.displayProperty != undefined) {
                    this.columnsProperties.push(this.viewField.viewFieldLOV.displayProperty.title)
                }
                this.viewField.viewFieldLOV.showProperties.forEach(p => {
                    if (p.name != this.viewField.viewFieldLOV.displayProperty.name) {
                        this.showProperties.push(p.name.value);
                        this.columnsProperties.push(p.title)
                    }
                });
            }

            // Needs css class width-100, width-50, width-33, width-25, width-20 and so on
            this.columnwidthclass = `width-${Math.round(100 / (this.showProperties.length + 1)).toString()}`;


            // Change the binding mode if the view is in New mode and the viewfield is required.
            // In this case, if the datasource has only one row it must be selected
            this.renderOnCreate = this.viewField.isRequired;


            if (this.viewField.allowSearch) {
                this.searchEnabled = true;
            }

            this.initSelectBox();
        }
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    private initSelectBox() {
        if (this.viewField.viewFieldLOV != null && this.viewField.viewFieldLOV.listOfValues != null &&
            this.viewField.viewFieldLOV.listOfValues.length > 0) {
            if (this.viewField.viewFieldType == eViewFieldTypes.DropDownList) {
                // list of fixed values (datasource = Array<Lov>)
                this.displayExpressionLOV = 'displayValue';
                this.valueExpressionLOV = 'value';
                this.dataSource = this.viewField.viewFieldLOV.listOfValues.sort((n1, n2) => {
                    if (n1 != null && n2 != null) {
                        if (n1.displayValue > n2.displayValue) {
                            return 1;
                        }
                        return -1;
                    }
                });
                let viewFieldData = this.viewField.getData();
                let displayValue = undefined;
                if (viewFieldData != undefined) {
                    if (typeof (viewFieldData) != "string") {
                        viewFieldData = viewFieldData.toString();
                        this.viewField.setData(viewFieldData);
                    }
                    displayValue = this.viewField.viewFieldLOV.listOfValues.filter(f => f.value.trim().toLowerCase() == viewFieldData.trim().toLowerCase());
                }

                if (displayValue != undefined && displayValue.length > 0) {
                    this.viewField.setShowValue(displayValue[0] != undefined ? displayValue[0].displayValue : viewFieldData);
                }
            }
        }
    }




    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    /** Event onChange */
    onChange($event) {
        this.viewField.hasError = false;
        this.viewField.textError = '';
    }
}