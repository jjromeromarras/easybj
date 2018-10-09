import { Component, Input, Output, EventEmitter, SimpleChange, OnChanges } from '@angular/core';
import { ViewGroup } from '../../model/application/views/viewgroups';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { Config } from '../../services/config.service';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { ViewPanel } from '../../model/interfaz/view/controls/viewpanel';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { eViewFieldTypes } from '../../model/interfaz/enums/eviewfieldtypes';
import { eViewControlTypes } from '../../model/interfaz/enums/eviewcontroltypes';
import { ViewGroupService } from '../../services/viewgroups/viewgroup.services';
import { constantsMsg } from '../../model/common/constantsMsg';


@Component(
    {
        selector: 'app-viewgroup',
        templateUrl: './viewgroup.component.html',
    }
)

export class ViewGroupComponent implements OnChanges {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPU METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Output() close = new EventEmitter();
    @Input() title: string;
    @Input() viewMode: eViewModes;
    @Input() selectedViewGroup: ViewGroup;

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
    constructor(public config: Config, private viewgroupservice: ViewGroupService) {
        this.auto = 'auto';
        this.viewMode = eViewModes.Edit;
        this.visible = true;

    }

    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        if (this.selectedViewGroup !== undefined) {
            this.SetViewEdit();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private SetViewEdit() {
        this.viewPanels = new Array<ViewPanel>();
        const viewpanel: ViewPanel = new ViewPanel();
        viewpanel.colSpan = 2;

        ViewHelper.createViewField('Name', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, true,
            viewpanel, this.selectedViewGroup.name);

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
        this.selectedViewGroup = undefined;
        this.onHiding(null);
    }

    onClickedSave() {
        let save = constantsMsg.NOERROR;
        if (this.viewMode === eViewModes.New) {
            save = this.viewgroupservice.AddViewGroup(this.selectedViewGroup);
        } else {
            save = this.viewgroupservice.EditViewGroup(this.selectedViewGroup);
        }

        if (save != constantsMsg.NOERROR)
            alert(save)
        else
            this.onClickedCancel();
    }
}