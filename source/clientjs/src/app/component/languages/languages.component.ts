import { Component, Input, Output, EventEmitter, SimpleChange } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { Config } from '../../services/config.service';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { Language } from '../../model/organization/language';
import { ViewPanel } from '../../model/interfaz/view/controls/viewpanel';
import { eViewFieldTypes } from '../../model/interfaz/enums/eviewfieldtypes';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { eViewControlTypes } from '../../model/interfaz/enums/eviewcontroltypes';
import { ActionConfirmationModes } from '../interfaz/dialog/ActionConfirmationModes';

@Component(
    {
        selector: 'app-languages',
        templateUrl: './languages.component.html',
    }
)

export class LanguagesComponent {


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPU METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Output() close = new EventEmitter();

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public pages: Array<PanelToolbar>;
    public title: string;
    public auto: string;
    public visible: boolean;
    public colData: any[];
    public viewMode: eViewModes;
    public selectedlanguage: Language;
    public viewPanels: Array<ViewPanel>;
    public showviewedit: boolean;
    public showDialog: boolean;
    public dialogTitle: string;
    public message: string;
    public dialogType: any;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config) {
        this.pages = new Array<PanelToolbar>();
        this.title = 'Languages';
        this.auto = 'auto';
        this.visible = true;
        this.SetInitialMenu();
        this.selectedlanguage = undefined;
        this.CreateColumns();
        this.showviewedit = false;
        this.showDialog = false;
        this.dialogType = ActionConfirmationModes.YesNo;
        this.dialogTitle = 'Remove language';
        this.message = 'Do you want to remove language?';
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private CreateColumns() {
        this.colData = [];
        this.colData.push(ViewHelper.getGridColumnDefinition('Name', false, 'name.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Country code', false, 'countryCode.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Is active', false, 'isActive.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Right to left', false, 'rightToLeft.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Is default language', false, 'isDefaultLanguage.value', true, true, true));
    }

    private SetViewEdit() {
        this.viewPanels = new Array<ViewPanel>();
        const viewpanel: ViewPanel = new ViewPanel();
        viewpanel.colSpan = 2;
        ViewHelper.createViewField('Name', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, true,
            viewpanel, this.selectedlanguage.name);
        ViewHelper.createViewField('Country code', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, true,
            viewpanel, this.selectedlanguage.countryCode);
        ViewHelper.createViewField('Is active', eViewFieldTypes.Boolean, eViewControlTypes.ViewField, 1, 2, false,
            viewpanel, this.selectedlanguage.isActive);
        ViewHelper.createViewField('Right to left', eViewFieldTypes.Boolean, eViewControlTypes.ViewField, 1, 2, false,
            viewpanel, this.selectedlanguage.rightToLeft);
        ViewHelper.createViewField('Is default language', eViewFieldTypes.Boolean, eViewControlTypes.ViewField, 1, 2, false,
            viewpanel, this.selectedlanguage.isDefaultLanguage);

        this.viewPanels.push(viewpanel);
    }

    private NewLanguage() {
        this.selectedlanguage = new Language();
        this.SetViewEdit();
        this.viewMode = eViewModes.New;
        this.showviewedit = true;
    }

    private EditLanguage() {
        if (this.selectedlanguage !== undefined) {
            this.SetViewEdit();
            this.viewMode = eViewModes.Edit;
            this.showviewedit = true;
        }
    }

    private RemoveLanguage() {
        if (this.selectedlanguage !== undefined) {
            this.showDialog = true;
        }
    }
    private SetInitialMenu() {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Language Page
        const languagepage = new PanelToolbar();
        languagepage.title = 'Language';
        languagepage.sequence = 1;
        // Languagae Group
        const languagegroup = new GroupActionToolbar();
        languagegroup.title = undefined;
        languagegroup.sequence = 1;

        const btaddlanguage = new ActionToolbar();
        btaddlanguage.title = 'Add';
        btaddlanguage.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btaddlanguage.sequence = 1;
        btaddlanguage.executeAction = (params: any) => {
            this.NewLanguage();
        };
        languagegroup.actions.push(btaddlanguage);

        const bteditlanguage = new ActionToolbar();
        bteditlanguage.title = 'Edit';
        bteditlanguage.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        bteditlanguage.sequence = 2;
        bteditlanguage.executeAction = (params: any) => {
            this.EditLanguage();
        };
        bteditlanguage.visibleAction = (params: any) => {
            return this.selectedlanguage !== undefined;
        };
        languagegroup.actions.push(bteditlanguage);

        const btdellanguage = new ActionToolbar();
        btdellanguage.title = 'Remove';
        btdellanguage.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btdellanguage.sequence = 3;
        btdellanguage.executeAction = (params: any) => {
            this.RemoveLanguage();
        };
        btdellanguage.visibleAction = (params: any) => {
            return this.selectedlanguage !== undefined;
        };
        languagegroup.actions.push(btdellanguage);
        languagepage.groups.push(languagegroup);

        this.pages.push(languagepage);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onHiding($event) {
        this.visible = false;
        this.close.emit();
    }

    onSelectionChange($event) {
        this.selectedlanguage = $event[0];
    }

    onClickedCancel() {
        this.showviewedit = false;
        this.viewMode = eViewModes.Read;
        this.selectedlanguage = undefined;
    }

    onClickedSave() {
        if (this.viewMode === eViewModes.New) {
            this.config.languages.push(this.selectedlanguage);
        }
        this.onClickedCancel();
    }

    onCloseDialog() {
        this.showDialog = false;
    }
}
