import { Component, Input, SimpleChange } from '@angular/core';
import { eViewFieldTypes } from '../../../../../model/interfaz/enums/eviewfieldtypes';
import { ViewField } from '../../../../../model/interfaz/view/controls/viewfield';
import { eViewModesHtml, eViewModes } from '../../../../../model/interfaz/enums/eviewmodes';
import { Config } from '../../../../../services/config.service';

@Component({
    selector: 'app-viewfieldtext',
    templateUrl: './viewfieldtext.component.html'
})
export class ViewFieldTextComponent {


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() viewField: ViewField;
    @Input() readyMode: Boolean;
    @Input() viewMode: eViewModes;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    eViewModes = eViewModesHtml;        // Access to enumeration from html
    eViewFieldTypes = eViewFieldTypes;  // Access to enumeration from html


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config) {
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NG METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        for (let propName in changes) {
            if (propName == 'viewField') {
                this.viewField.hasError = false;
                this.viewField.textError = '';
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    onChange() {
        this.viewField.hasError = false;
        this.viewField.textError = '';
    }
}