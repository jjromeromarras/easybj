import { Component, ViewChild, OnDestroy } from '@angular/core';
import { Config } from '../../services/config.service';
import { BroadcasterService } from 'ng-broadcaster';
import { DxTreeViewComponent } from 'devextreme-angular';


@Component(
    {
        selector: 'app-tree',
        templateUrl: './tree.component.html',
    }
)

export class TreeComponent implements OnDestroy {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @ViewChild('tree') treeView: DxTreeViewComponent;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public tenantdata = [{
        id: '1',
        text: 'Organization',
        expanded: false,
        items: [
            { id: '1_1', text: 'Jobs (0)', expanded: true },
            { id: '1_2', text: 'MenuItems (0)', expanded: true },
            { id: '1_3', text: 'Resources (0)', expanded: true },
            { id: '1_4', text: 'RFMenuItems (0)', expanded: true },
            { id: '1_5', text: 'Users groups (0)', expanded: true },
        ]
    }, {
        id: '2',
        text: 'Applications',
        expanded: true,
        items: [
        ]
    }];

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private subscriber: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
        this.registerTypeBroadcast();
    }


    ngOnDestroy() {
        if (this.subscriber !== undefined) {
            this.subscriber.unsubscribe();
        }
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private registerTypeBroadcast() {
        this.subscriber = this.messageeventservice.on<any>('onNewApplication')
            .subscribe(message => {
                this.createTreeApp();
            });
    }

    private createTreeApp() {
        this.tenantdata[1].items = [];
        this.config.applications.forEach(app => {

            this.tenantdata[1].items.push(this.createNodeApp(app.guid, app.name.value));
        });
        this.treeView.instance.option('items', this.tenantdata);
    }

    private createNodeApp(id: string, name: string): any {
        let expand = false;
        if (this.config.currentapp !== undefined) {
            expand = this.config.currentapp.name.value === name;
        }

        const ap = {
            id: id,
            text: name,
            expanded: expand,
            type: 'application',
            items: [
                {
                    id: name + '_ap',
                    text: 'Application elements',
                    expanded: expand,
                    items: [
                        { id: name + '_jobs', text: 'Jobs (0)' },
                        { id: name + '_menuitems', text: 'MenuItems (0)' },
                        { id: name + '_RFMenuItems', text: 'RFMenuItems (0)' },
                        { id: name + '_UsersGroups', text: 'Users group (0)' },
                    ]
                },
                { id: name + '_commands', text: 'Commands (0)' },
                { id: name + '_dialogs', text: 'Dialogs (0)' },
                { id: name + '_entities', text: 'Entities (0)' },
                { id: name + '_events', text: 'Events (0)' },
                { id: name + '_fieldtype', text: 'Field types (0)' },
                { id: name + '_list', text: 'List (0)' },
                { id: name + '_queries', text: 'Queries (0)' },
                { id: name + '_records', text: 'Records (0)' },
                { id: name + '_resources', text: 'Resources (0)' },
                { id: name + '_subscriptions', text: 'Validators (0)' },
                { id: name + '_views', text: 'Views (0)' },
                { id: name + '_viewgroups', text: 'View Groups (0)' },
                { id: name + '_wfaction', text: 'Workflow actions (0)' },
                { id: name + '_workflows', text: 'Workflows (0)' },
                { id: name + '_writing', text: 'Writing Model (0)' },
            ]
        };

        return ap;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public onItemExpanded(e) {
        const app = e.itemData;
        this.config.currentapp = this.config.applications.find(p => p.guid === app.id);
        this.createTreeApp();
    }

    public onItemSelectionChanged(e) {
        const item = e.itemData;
        this.messageeventservice.broadcast('selectOptionTreeApp', item.id);
    }

}
