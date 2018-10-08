import { Component, Input, Output, EventEmitter, SimpleChange } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { Config } from '../../services/config.service';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
import { ViewGroup } from '../../model/application/views/viewgroups';
import { BroadcasterService } from 'ng-broadcaster';
import { eWorkAreaType } from '../../model/interfaz/enums/eworkareatype';

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

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config, private messageeventservice: BroadcasterService) {
        this.SetInitialMenu();
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
        group.title = undefined;
        group.sequence = 1;

        const btadd = new ActionToolbar();
        btadd.title = 'Add';
        btadd.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btadd.sequence = 1;
        btadd.executeAction = (params: any) => {
            //this.NewLanguage();
        };
        group.actions.push(btadd);

        const btedit = new ActionToolbar();
        btedit.title = 'Edit';
        btedit.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btedit.sequence = 2;
        btedit.executeAction = (params: any) => {
            // this.EditLanguage();
        };
        btedit.visibleAction = (params: any) => {
            return this.selectedItem !== undefined;
        };
        group.actions.push(btedit);

        const btdel = new ActionToolbar();
        btdel.title = 'Remove';
        btdel.image = 'ApplicationResources/img/R052ApplicationAdd32x32.png';
        btdel.sequence = 3;
        btdel.executeAction = (params: any) => {
            //this.RemoveLanguage();
        };
        btdel.visibleAction = (params: any) => {
            return this.selectedItem !== undefined;
        };
        group.actions.push(btdel);
        page.groups.push(group);

        this.pages.push(page);
    }
}
