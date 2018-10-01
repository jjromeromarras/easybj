import { Component } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
import { Application } from '../../model/application/application';
import { Config } from '../../services/config.service';
import { BroadcasterService } from 'ng-broadcaster';
@Component(
    {
        selector: 'home',
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

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private subscriber: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
        this.pages = [];
        this.shownewapplication = false;
        this.SetInitialMenu();
    }

    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private SetInitialMenu() {

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Project Page
        let projectpage = new PanelToolbar();
        projectpage.title = "Project";
        projectpage.sequence = 1;
        // Group Program
        let programgroup = new GroupActionToolbar();
        programgroup.title = "Program";
        programgroup.sequence = 1;

        let btnnewapplication = new ActionToolbar();
        btnnewapplication.title = "New application";
        btnnewapplication.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btnnewapplication.sequence = 1;
        btnnewapplication.executeAction = (params: any) => {
            this.executeNewApplication(params);
        };

        let btnimport = new ActionToolbar();
        btnimport.title = "Import applications";
        btnimport.image = 'ApplicationResources/img/R057ApplicationImport32x32.png';
        btnimport.sequence = 2;

        programgroup.actions.push(btnnewapplication);
        programgroup.actions.push(btnimport);

        projectpage.groups.push(programgroup);

        // Group languages
        let languagesgroup = new GroupActionToolbar();
        languagesgroup.title = "Languages";
        languagesgroup.sequence = 2;

        let btnlanguages = new ActionToolbar();
        btnlanguages.title = "Management languages";
        btnlanguages.sequence = 1;
        btnlanguages.image = 'ApplicationResources/img/R298gestionar_idiomas_32x32.png';
        languagesgroup.actions.push(btnlanguages);
        projectpage.groups.push(languagesgroup);

        this.pages.push(projectpage);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Import/Export Page
        let importexport = new PanelToolbar();
        importexport.title = "Import/Export";
        importexport.sequence = 2;
        this.pages.push(importexport);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Packages management Page
        let packagemang = new PanelToolbar();
        packagemang.title = "Packages management";
        packagemang.sequence = 3;
        this.pages.push(packagemang);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Utils management Page
        let utils = new PanelToolbar();
        utils.title = "Utils";
        utils.sequence = 4;
        this.pages.push(utils);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS APPLICATION
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private executeNewApplication(params: any) {
        this.shownewapplication = true;    
        this.selectapp = new Application();
        this.opapplication='New Application'    
    }

    onApplicationCreationSaved($event) {
        this.shownewapplication = false;
        this.config.applications.push(this.selectapp);
        this.config.currentapp = this.selectapp;
        this.messageeventservice.broadcast('onNewApplication');
    }

    onApplicationCreationCanceled($event) {
        this.shownewapplication = false;
    }

}