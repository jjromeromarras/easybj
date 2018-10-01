import { Component, Input, SimpleChange } from '@angular/core';
import { ViewField } from '../../../../../model/interfaz/view/controls/viewfield';
import { eViewModes, eViewModesHtml } from '../../../../../model/interfaz/enums/eviewmodes';
import { eViewFieldTypes } from '../../../../../model/interfaz/enums/eviewfieldtypes';
import { Config } from '../../../../../services/config.service';

@Component({
    selector: 'app-viewfielddatetime',
    templateUrl: './viewfielddatetime.component.html'
})

export class ViewFieldDateTimeComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() viewField: ViewField;
    @Input() readyMode: Boolean;
    @Input() viewMode: eViewModes;
    @Input() containerName: string;
    @Input() value: string;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    eViewModes = eViewModesHtml;        // Access to enumeration from html
    eViewFieldTypes = eViewFieldTypes;  // Access to enumeration from html
    public displayValue = '';
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVAE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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

        this.displayValue = this.dateToLocale(this.viewField.showValue, this.viewField);
        this.viewField.data = new Date(this.dateToLocale(this.viewField.showValue, this.viewField));        
    }

    onChange() {
        this.viewField.hasError = false;
        this.viewField.textError = '';

    }

    public convertUTCDateToLocalDate(date: Date): Date {
        return new Date(Date.UTC(date.getFullYear(),
            date.getMonth(),
            date.getDate(),
            date.getHours(),
            date.getMinutes(),
            date.getSeconds()));
    }

    /** This method is used to parse the date into a grid template */
    public dateToLocale(date: string, viewField: ViewField): string {
        if (date != null && date != '') {
            if (viewField.viewFieldType == 'DateTime') {
                if (this.isInReadMode()) {
                    return this.convertUTCDateToLocalDate(new Date(date))
                        .toLocaleString(this.config.getSession().culture,
                            { year: 'numeric', day: '2-digit', month: '2-digit', hour: '2-digit', minute: '2-digit' });
                } else {
                    return this.convertUTCDateToLocalDate(new Date(date))
                        .toLocaleString('es',
                            { year: 'numeric', day: '2-digit', month: '2-digit', hour: '2-digit', minute: '2-digit' });
                }
            } else if (viewField.viewFieldType == 'Time') {
                return (this.convertUTCDateToLocalDate(new Date(date)))
                    .toLocaleTimeString(this.config.getSession().culture, { hour: '2-digit', minute: '2-digit' });
            } else {
                if (this.isInReadMode()) {
                    return new Date(date).toLocaleDateString(this.config.getSession().culture,
                        { year: 'numeric', day: '2-digit', month: '2-digit' });
                } else {
                    return new Date(date).toLocaleDateString('es',
                        { year: 'numeric', day: '2-digit', month: '2-digit' });
                }
            }
        } else {
            return undefined;
        }
    }

    private isInReadMode() {
        return this.viewMode == eViewModes.Read ;
    }


}