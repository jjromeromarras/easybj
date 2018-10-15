import { Component } from '@angular/core';
import { List } from '../../model/application/list/list';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { Config } from '../../services/config.service';
import { ActionConfirmationModes } from '../interfaz/dialog/ActionConfirmationModes';
import { eWorkAreaType } from '../../model/interfaz/enums/eworkareatype';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { BroadcasterService } from 'ng-broadcaster';
import { DialogResponse } from '../interfaz/dialog/dialogconstants';


@Component(
    {
        selector: 'app-lists',
        templateUrl: './lists.component.html',
    }
)

export class ListsComponent {
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public selectedItem: List;
    public pages: Array<PanelToolbar>;
    public colData: any[];
    public title: string;
    public viewMode: eViewModes;
    public showDialog: boolean;
    public showlist: boolean;
    public dialogTitle: string;
    public message: string;
    public dialogType: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
        this.SetInitialMenu();
        this.CreateColumns();
        this.showDialog = false;
        this.showlist = false;
        this.dialogType = ActionConfirmationModes.YesNo;
        this.dialogTitle = 'Remove list';
        this.message = 'Do you want to remove list?';
        this.viewMode = eViewModes.Read;



    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private SetInitialMenu() {

        this.pages = new Array<PanelToolbar>();
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Project Page
        const page = new PanelToolbar();
        page.title = 'Lists';
        page.sequence = 5;
        page.type = eWorkAreaType.List;

        const group = new GroupActionToolbar();
        group.title = 'List';
        group.sequence = 1;

        const btadd = new ActionToolbar();
        btadd.title = 'Add';
        btadd.image = 'ApplicationResources/img/R167anadir_grupo_vistas_32x32.png';
        btadd.sequence = 1;
        btadd.executeAction = (params: any) => {
            //this.NewViewGroup();
        };
        group.actions.push(btadd);

        const btedit = new ActionToolbar();
        btedit.title = 'Edit';
        btedit.image = 'ApplicationResources/img/R175editar_grupo_vistas_32x32.png';
        btedit.sequence = 2;
        btedit.executeAction = (params: any) => {
            //this.EditViewGroup();
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
            //   this.RemoveViewGroup();
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
        btviewuse.title = 'List Uses';
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
        return this.config.currentapp.lists.length > 0;
    }
    private CreateColumns() {
        this.colData = [];
        this.colData.push(ViewHelper.getGridColumnDefinition('Name', false, 'name.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Inheritance type', false,
            'usableAsEntityStereotype.inheritanceType', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Application Source', false, 'applicationsource', true, true, true));
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    onSelectionChange($event) {
        this.selectedItem = $event;
    }


    onCloseDialog(e) {

        if (e === DialogResponse.Yes) {
            //    if (this.viewgroupservie.RemoveViewGroup(this.selectedItem) === constantsMsg.NOERROR) {
            this.selectedItem = undefined;
            //  }
        }
        this.showDialog = false;
    }
}