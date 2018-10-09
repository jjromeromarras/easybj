import { Component, Input, Output, EventEmitter, SimpleChange, ViewChild } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { Config } from '../../services/config.service';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
import { ViewGroup } from '../../model/application/views/viewgroups';
import { BroadcasterService } from 'ng-broadcaster';
import { eWorkAreaType } from '../../model/interfaz/enums/eworkareatype';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { ActionConfirmationModes } from '../interfaz/dialog/ActionConfirmationModes';
import { DialogResponse } from '../interfaz/dialog/dialogconstants';
import { ViewGroupService } from '../../services/viewgroups/viewgroup.services';
import { constantsMsg } from '../../model/common/constantsMsg';

@Component(
    {
        selector: 'app-viewgroups',
        templateUrl: './viewgroups.component.html',
    }
)

export class ViewGroupsComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public selectedItem: ViewGroup;
    public viewgroups: Array<ViewGroup>;
    public pages: Array<PanelToolbar>;
    public colData: any[];
    public title: string;
    public viewMode: eViewModes;
    public showviewgroup: boolean;
    public showDialog: boolean;
    public dialogTitle: string;
    public message: string;
    public dialogType: any;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService, private viewgroupservie: ViewGroupService) {
        this.SetInitialMenu();
        this.CreateColumns();
        this.showviewgroup = false;
        this.showDialog = false;
        this.dialogType = ActionConfirmationModes.YesNo;
        this.dialogTitle = 'Remove view group';
        this.message = 'Do you want to remove view group?';
        this.viewMode = eViewModes.Read;
        this.messageeventservice.broadcast('addMenuGroup', this.pages);

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private SetInitialMenu() {

        this.pages = new Array<PanelToolbar>();
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Project Page
        const page = new PanelToolbar();
        page.title = 'View Groups';
        page.sequence = 5;
        page.type = eWorkAreaType.ViewGroups;

        const group = new GroupActionToolbar();
        group.title = 'View Group';
        group.sequence = 1;

        const btadd = new ActionToolbar();
        btadd.title = 'Add';
        btadd.image = 'ApplicationResources/img/R167anadir_grupo_vistas_32x32.png';
        btadd.sequence = 1;
        btadd.executeAction = (params: any) => {
            this.NewViewGroup();
        };
        group.actions.push(btadd);

        const btedit = new ActionToolbar();
        btedit.title = 'Edit';
        btedit.image = 'ApplicationResources/img/R175editar_grupo_vistas_32x32.png';
        btedit.sequence = 2;
        btedit.executeAction = (params: any) => {
            this.EditViewGroup();
        };
        btedit.visibleAction = (params: any) => {
            return this.chekVisibility();
        };
        group.actions.push(btedit);

        const btdel = new ActionToolbar();
        btdel.title = 'Remove';
        btdel.image = 'ApplicationResources/img/R179eliminar_grupo_vistas_32x32.png';
        btdel.sequence = 3;
        btdel.executeAction = (params: any) => {
            this.RemoveViewGroup();
        };
        btdel.visibleAction = (params: any) => {
            return this.chekVisibility();
        };
        group.actions.push(btdel);
        page.groups.push(group);

        const gvisible = new GroupActionToolbar();
        gvisible.title = 'Visibility';
        gvisible.sequence = 2;

        const btviewuse = new ActionToolbar();
        btviewuse.title = 'View Uses';
        btviewuse.image = 'ApplicationResources/img/R099Released32x32.png';
        btviewuse.sequence = 1;
        btviewuse.executeAction = (params: any) => {
            //this.NewLanguage();
        };
        btviewuse.visibleAction = (params: any) => {
            return this.chekVisibility();
        };
        gvisible.actions.push(btviewuse);
        page.groups.push(gvisible);

        this.pages.push(page);
    }

    private chekVisibility(): boolean {
        return this.config.currentapp.viewgroups.length > 0
    }
    private CreateColumns() {
        this.colData = [];
        this.colData.push(ViewHelper.getGridColumnDefinition('Name', false, 'name.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Inheritance type', false, 'usableAsEntityStereotype.inheritanceType', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Application Source', false, 'applicationsource', true, true, true));
    }

    private NewViewGroup() {
        this.title = 'New View Group';
        this.viewMode = eViewModes.New;
        this.selectedItem = new ViewGroup();
        this.selectedItem.applicationsource = this.config.currentapp.name.value;
        this.showviewgroup = true;
    }

    private EditViewGroup() {
        if (this.selectedItem !== undefined) {
            this.title = 'Edit View Group';
            this.viewMode = eViewModes.Edit;
            this.showviewgroup = true;
        }
    }

    private RemoveViewGroup() {
        if (this.selectedItem !== undefined) {
            this.showDialog = true;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    onSelectionChange($event) {
        this.selectedItem = $event[0];
    }

    onCloseViewGroup() {
        this.showviewgroup = false;
        this.selectedItem = undefined;
    }

    onCloseDialog(e) {
        if (e == DialogResponse.Yes) {
            if (this.viewgroupservie.RemoveViewGroup(this.selectedItem) == constantsMsg.NOERROR) {
                this.selectedItem = undefined;
            }
        }
        this.showDialog = false;
    }
}
