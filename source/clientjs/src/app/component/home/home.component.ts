import { Component } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
import { Application } from '../../model/application/application';
import { Config } from '../../services/config.service';
import { BroadcasterService } from 'ng-broadcaster';
@Component(
    {
        selector: 'app-home',
        templateUrl: './home.component.html',
    }
)

export class HomeComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public pages: Array<PanelToolbar>;
    public shownewapplication: boolean;
    public opapplication: string;
    public selectapp: Application;
    public showlanguages: boolean;
    public showviewgorups: boolean;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private subscriber: any;
    private subdelmenu: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
        this.pages = [];
        this.shownewapplication = false;
        this.showviewgorups = false;
        this.showlanguages = false;
        this.SetInitialMenu();
        this.registerTypeBroadcast();
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private SetInitialMenu() {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Project Page
        const projectpage = new PanelToolbar();
        projectpage.title = 'Project';
        projectpage.sequence = 1;
        // Group Program
        const programgroup = new GroupActionToolbar();
        programgroup.title = 'Program';
        programgroup.sequence = 1;

        const btnnewapplication = new ActionToolbar();
        btnnewapplication.title = 'New application';
        btnnewapplication.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btnnewapplication.sequence = 1;
        btnnewapplication.executeAction = (params: any) => {
            this.executeNewApplication(params);
        };

        const btneditapplication = new ActionToolbar();
        btneditapplication.title = 'Edit application';
        btneditapplication.image = 'ApplicationResources/img/R054ApplicationEdit32x32.png';
        btneditapplication.sequence = 1;
        btneditapplication.executeAction = (params: any) => {
            this.executeEditApplication(params);
        };

        const btnremoveapplication = new ActionToolbar();
        btnremoveapplication.title = 'Remove application';
        btnremoveapplication.image = 'ApplicationResources/img/R053ApplicationRemove32x32.png';
        btnremoveapplication.sequence = 1;
        btnremoveapplication.executeAction = (params: any) => {
            this.executeNewApplication(params);
        };

        const btnimport = new ActionToolbar();
        btnimport.title = 'Import applications';
        btnimport.image = 'ApplicationResources/img/R057ApplicationImport32x32.png';
        btnimport.sequence = 2;

        programgroup.actions.push(btnnewapplication);
        programgroup.actions.push(btneditapplication);
        programgroup.actions.push(btnremoveapplication);
        programgroup.actions.push(btnimport);

        projectpage.groups.push(programgroup);

        // Group languages
        const languagesgroup = new GroupActionToolbar();
        languagesgroup.title = 'Languages';
        languagesgroup.sequence = 2;

        const btnlanguages = new ActionToolbar();
        btnlanguages.title = 'Management languages';
        btnlanguages.sequence = 1;
        btnlanguages.image = 'ApplicationResources/img/R298gestionar_idiomas_32x32.png';
        btnlanguages.executeAction = (params: any) => {
            this.executeShowLangauges(params);
        };
        languagesgroup.actions.push(btnlanguages);
        projectpage.groups.push(languagesgroup);

        this.pages.push(projectpage);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Import/Export Page
        const importexport = new PanelToolbar();
        importexport.title = 'Import/Export';
        importexport.sequence = 2;
        this.pages.push(importexport);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Packages management Page
        const packagemang = new PanelToolbar();
        packagemang.title = 'Packages management';
        packagemang.sequence = 3;
        this.pages.push(packagemang);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Utils management Page
        const utils = new PanelToolbar();
        utils.title = 'Utils';
        utils.sequence = 4;
        this.pages.push(utils);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private executeNewApplication(params: any) {
        this.shownewapplication = true;
        this.selectapp = new Application();
        this.opapplication = 'New Application';
    }

    private executeEditApplication(params: any) {
        if (this.config.currentapp != undefined) {
            this.selectapp = this.config.currentapp;
            this.shownewapplication = true;
            this.opapplication = 'Edit Application';
        }
    }

    private executeShowLangauges(params: any) {
        this.showlanguages = true;
    }

    private registerTypeBroadcast() {
        this.subscriber = this.messageeventservice.on<any>('addMenuGroup')
            .subscribe(message => {
                message.forEach(pg => {
                    this.pages.push(pg);
                });

            });

        this.subdelmenu = this.messageeventservice.on<any>('delMenuGroup')
            .subscribe(message => {
                this.pages = this.pages.filter(p => p.type !== message.type);

            });
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onApplicationCreationSaved($event) {
        this.shownewapplication = false;
        this.config.applications.push(this.selectapp);
        this.config.currentapp = this.selectapp;
        this.messageeventservice.broadcast('onNewApplication');
    }

    onApplicationCreationCanceled($event) {
        this.shownewapplication = false;
    }

    onCloseLanguage($event) {
        this.showlanguages = false;
    }
}
