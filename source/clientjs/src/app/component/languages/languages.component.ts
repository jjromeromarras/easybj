import { Component, Input, Output, EventEmitter, SimpleChange } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { Config } from '../../services/config.service';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { Language } from '../../model/organization/language';

@Component(
    {
        selector: 'app-languages',
        templateUrl: './languages.component.html',
    }
)

export class LanguageComponent {


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
    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config) {
        this.pages = new Array<PanelToolbar>();
        this.title = "Languages";
        this.auto = "auto";
        this.visible = true;
        this.SetInitialMenu();
        let language = new Language();
        language.name.value='Español';
        language.countryCode='es';        
        this.config.languages.push(language);
        this.CreateColumns();
        
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private CreateColumns() {
        this.colData = [];
        this.colData.push(ViewHelper.getGridColumnDefinition('Name', false, 'name.value', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Country code', false, 'countryCode', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Is active', false, 'isActive', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Right to left', false, 'rightToLeft', true, true, true));
        this.colData.push(ViewHelper.getGridColumnDefinition('Is default language', false, 'isDefaultLanguage', true, true, true));
    }

    private SetInitialMenu() {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Language Page
        let languagepage = new PanelToolbar();
        languagepage.title = "Language";
        languagepage.sequence = 1;
        // Languagae Group
        let languagegroup = new GroupActionToolbar();
        languagegroup.title = undefined;
        languagegroup.sequence = 1;

        let btaddlanguage = new ActionToolbar();
        btaddlanguage.title = "Add";
        btaddlanguage.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btaddlanguage.sequence = 1;
        btaddlanguage.executeAction = (params: any) => {
            //this.executeNewApplication(params);
        };
        languagegroup.actions.push(btaddlanguage);

        let bteditlanguage = new ActionToolbar();
        bteditlanguage.title = "Edit";
        bteditlanguage.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        bteditlanguage.sequence = 2;
        bteditlanguage.executeAction = (params: any) => {
            //this.executeNewApplication(params);
        };
        languagegroup.actions.push(bteditlanguage);

        let btdellanguage = new ActionToolbar();
        btdellanguage.title = "Remove";
        btdellanguage.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btdellanguage.sequence = 3;
        btdellanguage.executeAction = (params: any) => {
            //this.executeNewApplication(params);
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
}