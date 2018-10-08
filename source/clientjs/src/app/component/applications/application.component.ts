import { Component, Input, Output, EventEmitter, OnChanges, SimpleChange } from '@angular/core';
import { Application } from '../../model/application/application';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { ViewPanel } from '../../model/interfaz/view/controls/viewpanel';
import { eViewFieldTypes } from '../../model/interfaz/enums/eviewfieldtypes';
import { eViewControlTypes } from '../../model/interfaz/enums/eviewcontroltypes';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';

@Component(
    {
        selector: 'app-application',
        templateUrl: './application.component.html',
    }
)

export class ApplicationComponent implements OnChanges {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public cancelstr: string;
    public savestr: string;
    public auto: string;
    public inlineCreationVisible: boolean;
    public viewMode: eViewModes;
    public viewPanels: Array<ViewPanel>;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPU METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() title: string;
    @Input() application: Application;
    @Output() save = new EventEmitter();
    @Output() cancel = new EventEmitter();
    @Output() error = new EventEmitter();

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor() {
        this.inlineCreationVisible = true;
        this.cancelstr = 'Cancel';
        this.savestr = 'Save';
        this.auto = 'auto';
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NG METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        if (this.application !== undefined) {
            /// Name
            this.viewPanels = new Array<ViewPanel>();
            const viewpanel: ViewPanel = new ViewPanel();
            viewpanel.colSpan = 2;
            ViewHelper.createViewField('Name', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, true,
                viewpanel, this.application.name);
            ViewHelper.createViewField('Description', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, false,
                viewpanel, this.application.description);
            ViewHelper.createViewField('Application imagen folder', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, false,
                viewpanel, this.application.imagesFolder);

            this.viewPanels.push(viewpanel);
        }
    }

    /**Cancel button, hides popup */
    onClickedCancel($event) {
        this.inlineCreationVisible = false;
        $event.preventDefault();
        this.cancel.emit('Canceled');
    }

    onClickedSave($event) {
        this.inlineCreationVisible = false;
        $event.preventDefault();
        this.save.emit('Save');
    }

    onHiding($event) {
        this.inlineCreationVisible = false;
        this.cancel.emit('Canceled');
    }
}
