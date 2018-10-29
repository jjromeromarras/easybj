import { Component, Input, Output, EventEmitter, SimpleChange, OnChanges } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { Config } from '../../services/config.service';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { ViewPanel } from '../../model/interfaz/view/controls/viewpanel';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { eViewFieldTypes } from '../../model/interfaz/enums/eviewfieldtypes';
import { eViewControlTypes } from '../../model/interfaz/enums/eviewcontroltypes';
import { constantsMsg } from '../../model/common/constantsMsg';
import { Record } from '../../model/application/record/record';
import { RecordService } from '../../services/records/record.service';


@Component(
    {
        selector: 'app-record',
        templateUrl: './record.component.html',
    }
)

export class RecordComponent implements OnChanges {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPU METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Output() close = new EventEmitter();
    @Input() title: string;
    @Input() viewMode: eViewModes;
    @Input() selected: Record;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public pages: Array<PanelToolbar>;
    public auto: string;
    public visible: boolean;
    public viewPanels: Array<ViewPanel>;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private service: RecordService) {
        this.auto = 'auto';
        this.viewMode = eViewModes.Edit;
        this.visible = true;

    }

    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        if (this.selected !== undefined) {
            this.SetViewEdit();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private SetViewEdit() {
        this.viewPanels = new Array<ViewPanel>();
        const viewpanel: ViewPanel = new ViewPanel();
        viewpanel.colSpan = 4;

        ViewHelper.createViewField('Name', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, true,
            viewpanel, this.selected.name);
        ViewHelper.createViewField('Description', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 2, 2, false,
            viewpanel, this.selected.description);

        this.viewPanels.push(viewpanel);
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onHiding($event) {
        this.visible = false;
        this.close.emit();
    }

    onClickedCancel() {
        this.viewMode = eViewModes.Read;
        this.selected = undefined;
        this.onHiding(null);
    }

    onClickedSave() {
        let save = constantsMsg.NOERROR;
        if (this.viewMode === eViewModes.New) {
            save = this.service.Add(this.selected);
        } else {
            save = this.service.Edit(this.selected);
        }

        if (save !== constantsMsg.NOERROR) {
            alert(save);
        } else {
            this.onClickedCancel();
        }
    }
}