import { Component, Input, Output, EventEmitter, OnChanges, SimpleChange } from '@angular/core';
import { Application } from '../../model/application/application';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { ViewPanel } from '../../model/interfaz/view/controls/viewpanel';
import { eViewFieldTypes } from '../../model/interfaz/enums/eviewfieldtypes';
import { eViewControlTypes } from '../../model/interfaz/enums/eviewcontroltypes';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { Config } from '../../services/config.service';
import { ApplicationService } from '../../services/applications/application.services';
import { constantsMsg } from '../../model/common/constantsMsg';

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
    public viewPanels: Array<ViewPanel>;
    public appData: Array<Application>;
    public showCheckBoxesMode: string;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPU METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() title: string;
    @Input() application: Application;
    @Input() viewMode: eViewModes;
    @Output() save = new EventEmitter();
    @Output() cancel = new EventEmitter();
    @Output() error = new EventEmitter();

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config, private applicationservice: ApplicationService) {
        this.inlineCreationVisible = true;
        this.cancelstr = 'Cancel';
        this.savestr = 'Save';
        this.auto = 'auto';
        this.showCheckBoxesMode = 'normal';
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
            this.appData = this.config.applications.filter(p => p.guid != this.application.guid);
        }
    }

    /**Cancel button, hides popup */
    onClickedCancel() {
        this.inlineCreationVisible = false;
        this.cancel.emit('Canceled');
    }

    onClickedSave() {
        let msg = constantsMsg.NOERROR;
        if (this.viewMode === eViewModes.New) {
            msg = this.applicationservice.AddApplication(this.application);
        } else {
            msg = this.applicationservice.EditApplication(this.application);
        }
        if (msg !== constantsMsg.NOERROR) {
            alert(msg);
        } else {
            this.onClickedCancel();
        }
        this.save.emit('Save');
    }

    onHiding($event) {
        this.onClickedCancel();
    }
}
