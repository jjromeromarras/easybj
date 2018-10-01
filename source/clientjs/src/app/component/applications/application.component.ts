import { Component, Input, Output, EventEmitter, SimpleChange } from '@angular/core';
import { Application } from '../../model/application/application';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { ViewPanel } from '../../model/interfaz/view/controls/viewpanel';
import { ViewField } from '../../model/interfaz/view/controls/viewfield';
import { eViewFieldTypes } from '../../model/interfaz/enums/eviewfieldtypes';
import { eViewControlTypes } from '../../model/interfaz/enums/eviewcontroltypes';

@Component(
    {
        selector: 'app-application',
        templateUrl: './application.component.html',
    }
)

export class ApplicationComponent {

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

        this.cancelstr = "Cancel";
        this.savestr = "Save";
        this.auto = "auto";
      


    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NG METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        if (this.application != undefined) {
            /// Name
            this.viewPanels = new Array<ViewPanel>();
            const viewpanel: ViewPanel = new ViewPanel();
            viewpanel.colSpan = 2;
            this.createViewField('Name', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, true,
                viewpanel, this.application.name);
            this.createViewField('Description', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, false,
                viewpanel, this.application.description);
            this.createViewField('Application imagen folder', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, false,
                viewpanel, this.application.imagesFolder);

            this.viewPanels.push(viewpanel);
        }
    }
    private createViewField(title: string, vftype: string, type: string, sequence: number, colSpan: number,
        isRequired: boolean, panel: ViewPanel, data: any) {

        const vf = new ViewField();
        vf.title = title;
        vf.isRequired = isRequired;
        vf.viewFieldType = vftype;
        vf.type = type;
        vf.sequence = sequence;
        vf.colSpan = colSpan;
        vf.dataobj = data;
        panel.controls.push(vf);
        panel.viewFields.push(vf);

    }
    /**Cancel button, hides popup */
    onClickedCancel($event) {
        // we need to force the emit because the popup stays open         
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
        // When closeOnCancel is set true, the popup only hides on the event onSave and the cancel emit mustn't be send
        this.cancel.emit('Canceled');
    }
}