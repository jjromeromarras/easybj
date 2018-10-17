import { Component, OnDestroy } from '@angular/core';
import { Config } from '../../services/config.service';
import { BroadcasterService } from 'ng-broadcaster';
import { WorkPageControl } from '../../model/interfaz/view/controls/workpagecontrol';
import { eWorkAreaType } from '../../model/interfaz/enums/eworkareatype';
@Component(
    {
        selector: 'app-workarea',
        templateUrl: './workarea.component.html',
    }
)

export class WorkAreaComponent implements OnDestroy {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public pages: Array<WorkPageControl>;
    public index: number;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private sub: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
        this.index = 0;
        this.pages = new Array<WorkPageControl>();
        const wk = new WorkPageControl();
        wk.title = 'News';
        wk.type = eWorkAreaType.News;
        this.pages.push(wk);
        this.sub = undefined;
        this.registerTypeBroadcast();
    }

    ngOnDestroy() {
        if (this.sub != undefined) {
            this.sub = undefined;
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private registerTypeBroadcast() {
        if (this.sub === undefined) {
            this.sub = this.messageeventservice.on<string>('selectOptionTreeApp')
                .subscribe(message => {
                    if (message.indexOf('viewgroups') !== -1) {
                        this.createSelectedTab(eWorkAreaType.ViewGroups, 'View Groups');
                    }
                    if (message.indexOf('list') !== -1) {
                        this.createSelectedTab(eWorkAreaType.List, 'List');
                    }
                    if (message.indexOf('fieldtypes') !== -1) {
                        this.createSelectedTab(eWorkAreaType.FieldTypes, 'Field Types');
                    }

                });
        }
    }

    private createSelectedTab(type: any, title: string) {
        let count = this.pages.findIndex(p => p.type === type);
        if (count === -1) {
            const wk = new WorkPageControl();
            wk.title = title;
            wk.type = type;
            this.pages.push(wk);
            count = this.pages.length - 1;
        }
        this.index = count;

    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onCloseTab(page) {
        this.pages = this.pages.filter(p => p.type !== page.type);
        this.messageeventservice.broadcast('delMenuGroup', page);
    }

    onSelectionChanged(page) {
        if (page.addedItems !== undefined) {
            const type = page.addedItems[0].type;
            this.messageeventservice.broadcast('addMenuComponent', type);
        }
    }
}