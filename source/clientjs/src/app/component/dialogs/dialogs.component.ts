import { Component } from '@angular/core';
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
import { constantsMsg } from '../../model/common/constantsMsg';
import { CheckStatus } from '../../model/common/checkstatus';
import { Dialog } from '../../model/application/dialogs/dialogs';
import { DialogsService } from '../../services/dialogs/dialogs.services';


@Component(
    {
        selector: 'app-dialogs',
        templateUrl: './dialogs.component.html',
    }
)

export class DialogsComponent {
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public selectedItem: Dialog;
    public pages: Array<PanelToolbar>;
    public colData: any[];
    public title: string;
    public viewMode: eViewModes;
    public showDialog: boolean;
    public showdata: boolean;
    public dialogTitle: string;
    public message: string;
    public dialogType: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService,
        private service: DialogsService) {
        this.SetInitialMenu();
        this.CreateColumns();
        this.showDialog = false;
        this.showdata = false;
        this.dialogType = ActionConfirmationModes.YesNo;
        this.dialogTitle = 'Remove Dialog';
        this.message = 'Do you want to remove Dialog?';
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
        page.title = 'Dialogs';
        page.sequence = 5;
        page.type = eWorkAreaType.FieldTypes;

        const group = new GroupActionToolbar();
        group.title = 'Dialog';
        group.sequence = 1;

        const btadd = new ActionToolbar();
        btadd.title = 'Add';
        btadd.image = 'ApplicationResources/img/R112alta_tipo_dato_32x32.png';
        btadd.sequence = 1;
        btadd.executeAction = (params: any) => {
            this.New();
        };
        group.actions.push(btadd);

        const btedit = new ActionToolbar();
        btedit.title = 'Edit';
        btedit.image = 'ApplicationResources/img/R121editar_tipo_dato_32x32.png';
        btedit.sequence = 2;
        btedit.executeAction = (params: any) => {
            this.Edit();
        };
        btedit.visibleAction = (params: any) => {
            return this.chekVisibilityCheckIn();
        };
        group.actions.push(btedit);

        const btdel = new ActionToolbar();
        btdel.title = 'Remove';
        btdel.image = 'ApplicationResources/img/R115borrar_tipo_dato_32x32.png';
        btdel.sequence = 3;
        btdel.executeAction = (params: any) => {
            this.Remove();
        };
        btdel.visibleAction = (params: any) => {
            return this.chekVisibilityCheckIn();
        };
        group.actions.push(btdel);
        page.groups.push(group);

        const gcheckin = new GroupActionToolbar();
        gcheckin.title = 'Checkin/Checkout';
        gcheckin.sequence = 3;

        const btcheckin = new ActionToolbar();
        btcheckin.title = 'Checkin';
        btcheckin.image = 'ApplicationResources/img/R058checkinResource32x32.png';
        btcheckin.executeAction = (params: any) => {
            this.Checkin();
        };
        btcheckin.visibleAction = (params: any) => {
            return this.chekVisibilityCheckIn();
        };
        const btcheckout = new ActionToolbar();
        btcheckout.title = 'Checkout';
        btcheckout.image = 'ApplicationResources/img/R060CheckoutResource32x32.png';
        btcheckout.executeAction = (params: any) => {
            this.Checkout();
        };
        btcheckout.visibleAction = (params: any) => {
            return this.chekVisibilityCheckOut();
        };

        
        gcheckin.actions.push(btcheckin);
        gcheckin.actions.push(btcheckout);

        page.groups.push(gcheckin);

        const gvisible = new GroupActionToolbar();
        gvisible.title = 'Visibility';
        gvisible.sequence = 3;

        const btviewuse = new ActionToolbar();
        btviewuse.title = 'Dialog Uses';
        btviewuse.image = 'ApplicationResources/img/R099Released32x32.png';
        btviewuse.sequence = 1;
        btviewuse.executeAction = (params: any) => {
            // this.NewLanguage();
        };
        btviewuse.visibleAction = (params: any) => {
            return this.chekVisibility();
        };
        gvisible.actions.push(btviewuse);

        page.groups.push(gvisible);

        this.pages.push(page);
    }

    private chekVisibility(): boolean {
      //  return this.config.currentapp.Dialogs.length > 0;
      return true;
    }

    private chekVisibilityCheckIn(): boolean {
        return this.chekVisibility() && this.selectedItem !== undefined && this.selectedItem.checkStatus === CheckStatus.Editable;
    }
    private chekVisibilityCheckOut(): boolean {
        return this.chekVisibility() && this.selectedItem !== undefined && this.selectedItem.checkStatus === CheckStatus.Default;
    }
    private CreateColumns() {
        this.colData = [];
        this.colData.push(ViewHelper.getGridColumnDefinition('Check status', false, 'checkStatus', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Name', false, 'name.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Description', false, 'description.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Locked by', false, 'lockedBy', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Inheritance type', false,
            'usableAsEntityStereotype.inheritanceType', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Application Source', false, 'applicationsource', true, true, true));
    }

    private New() {
        this.title = 'New Dialog';
        this.viewMode = eViewModes.New;
        this.selectedItem = new Dialog();
        this.selectedItem.applicationsource = this.config.currentapp.name.value;
        this.showdata = true;
    }

    private Edit() {
        if (this.selectedItem !== undefined) {
            this.title = 'Edit Dialog';
            this.viewMode = eViewModes.Edit;
            this.showdata = true;
        }
    }

    private Remove() {
        if (this.selectedItem !== undefined) {
            this.showDialog = true;
        }
    }

    private Checkin() {
        if (this.selectedItem !== undefined && this.selectedItem.checkStatus === CheckStatus.Editable) {
            const result = this.service.CheckIn(this.selectedItem);
            if (result !== constantsMsg.NOERROR) {
                alert(result);
            }
        }
    }

    private Checkout() {
        if (this.selectedItem !== undefined && this.selectedItem.checkStatus === CheckStatus.Default) {
            const result = this.service.CheckOut(this.selectedItem);
            if (result !== constantsMsg.NOERROR) {
                alert(result);
            }
        }
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    onSelectionChange($event) {
        this.selectedItem = $event;
    }

    onCloseFieldType() {
        this.showDialog = false;
        this.selectedItem = undefined;
    }

    onCloseDialog(e) {

        if (e === DialogResponse.Yes) {
            if (this.service.Remove(this.selectedItem) === constantsMsg.NOERROR) {
                this.selectedItem = undefined;
            }
        }
        this.showDialog = false;
    }
}