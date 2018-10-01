import { Component, Input, SimpleChange } from '@angular/core';
import { ViewField } from '../../../../../model/interfaz/view/controls/viewfield';
import { eViewModes } from '../../../../../model/interfaz/enums/eviewmodes';
import { eViewFieldTypes } from '../../../../../model/interfaz/enums/eviewfieldtypes';
import { Config } from '../../../../../services/config.service';

@Component({
    selector: 'app-viewfieldboolean',
    templateUrl: './viewfieldboolean.component.html'
})

export class ViewFieldBooleanComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() viewField: ViewField;
    @Input() readyMode: Boolean;
    @Input() viewMode: eViewModes;
    @Input() containerName: string;
    @Input() selectedRows: number;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    eViewModes = eViewModes;        // Access to enumeration from html
    eViewFieldTypes = eViewFieldTypes;  // Access to enumeration from html

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private booleanValue: boolean;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config) {
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NG METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ngOnInit() {
        this.booleanValue = this.viewField.getData() == 'undefinedValue' ? false : this.viewField.getData();
        this.viewField.setData(this.booleanValue);
    }

    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        for (let propName in changes) {
            if (propName == 'viewField') {
                this.viewField.hasError = false;
                this.viewField.textError = '';
            }
        }
        if (this.viewMode == eViewModes.New) {
            // On creation, if the viewfield has not value, it represents false
            this.booleanValue = this.viewField.getData() == 'undefinedValue' ? false : this.viewField.getData();
        } else {
            this.booleanValue = this.viewField.getData() != 'norTrueNorFalse' ? this.viewField.getData() : undefined;
        }
        if (this.selectedRows == 1 && this.booleanValue == undefined) {
            this.booleanValue = false;
            this.viewField.setData(false);
        }
        this.viewField.setData(this.booleanValue);
        this.viewField.setShowValue(this.booleanValue);
    }

    onChange() {
        this.viewField.hasError = false;
        this.viewField.textError = '';
        this.booleanValue = this.viewField.getData();
        if (this.booleanValue == undefined) {
            this.booleanValue = false;
            this.viewField.setData(false);
        }
    }
}