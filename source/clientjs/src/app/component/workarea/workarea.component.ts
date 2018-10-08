import { Component } from '@angular/core';
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

export class WorkAreaComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public pages: Array<WorkPageControl>;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    private sub: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
    constructor(public config: Config, private messageeventservice: BroadcasterService) {

        this.pages = new Array<WorkPageControl>();
        this.registerTypeBroadcast();
    }

    private registerTypeBroadcast() {
        this.sub = this.messageeventservice.on<string>('selectOptionTreeApp')
            .subscribe(message => {
                if (message.indexOf('viewgroups') !== -1) {
                    if (this.pages.findIndex(p => p.type === eWorkAreaType.ViewGroups) === -1) {
                        const wk = new WorkPageControl();
                        wk.title = 'View Groups';
                        wk.type = eWorkAreaType.ViewGroups;
                        this.pages.push(wk);
                    }
                }

            });
    }

    onCloseTab(page) {
        this.pages = this.pages.filter(p => p.type !== page.type);
        this.messageeventservice.broadcast('delMenuGroup', page);
    }
}