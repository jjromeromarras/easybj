import { Component, ViewChild, OnDestroy } from '@angular/core';
import { Config } from '../../services/config.service';
import { BroadcasterService } from 'ng-broadcaster';
import { DxTreeViewComponent } from 'devextreme-angular';
import { Application } from '../../model/application/application';


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
        image: 'ApplicationResources/img16/appelements.png',
        expanded: false,
        items: [
            { id: '_jobs', text: 'Jobs (0)', image: 'ApplicationResources/img16/jobs.png' },
            { id: '_menuitems', text: 'MenuItems (0)', image: 'ApplicationResources/img16/menuitems.png' },
            { id: '_resources', text: 'Resources (0)', image: 'ApplicationResources/img16/resources.png' },
            { id: '_RFMenuItems', text: 'RFMenuItems (0)', image: 'ApplicationResources/img16/rfmenu.png' },
            { id: '_UsersGroups', text: 'Users group (0)', image: 'ApplicationResources/img16/usergroups.png' },
        ]
    }, {
        id: '2',
        text: 'Applications',
        expanded: true,
        image: 'ApplicationResources/img16/applications.png',
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
            const node = this.createNodeApp(app);
            this.tenantdata[1].items.push(node);
        });
        this.treeView.instance.option('items', this.tenantdata);
    }

    private createNodeApp(app: Application): any {
        let expand = false;
        const id = app.guid;
        const name = app.name.value;
        if (this.config.currentapp !== undefined) {
            expand = this.config.currentapp.name.value === name;
        }

        const ap = {
            id: id,
            text: name,
            expanded: expand,
            type: 'application',
            image: !expand ? 'ApplicationResources/img16/application.png' : 'ApplicationResources/img16/currentapplication.png',
            items: [
                {
                    id: name + '_ap',
                    text: 'Application elements',
                    expanded: expand,
                    image: 'ApplicationResources/img16/appelements.png',
                    items: [
                        { id: name + '_jobs', text: 'Jobs (0)', image: 'ApplicationResources/img16/jobs.png' },
                        { id: name + '_menuitems', text: 'MenuItems (0)', image: 'ApplicationResources/img16/menuitems.png' },
                        { id: name + '_RFMenuItems', text: 'RFMenuItems (0)', image: 'ApplicationResources/img16/rfmenu.png' },
                        { id: name + '_UsersGroups', text: 'Users group (0)', image: 'ApplicationResources/img16/usergroups.png' },
                    ]
                },
                { id: name + '_commands', text: 'Commands (0)', image: 'ApplicationResources/img16/comando.png' },
                { id: name + '_dialogs', text: 'Dialogs (0)', image: 'ApplicationResources/img16/dialogs.png' },
                { id: name + '_entities', text: 'Entities (0)', image: 'ApplicationResources/img16/entities.png' },
                { id: name + '_events', text: 'Events (0)', image: 'ApplicationResources/img16/events.png' },
                { id: name + '_fieldtypes', text: 'Field types ('+app.fieltypes.length+')', image: 'ApplicationResources/img16/fieldtypes.png' },
                { id: name + '_list', text: 'Lists (0)', image: 'ApplicationResources/img16/lists.png' },
                { id: name + '_queries', text: 'Queries (0)', image: 'ApplicationResources/img16/queries.png' },
                { id: name + '_records', text: 'Records (0)', image: 'ApplicationResources/img16/records.png' },
                { id: name + '_resources', text: 'Resources (0)', image: 'ApplicationResources/img16/resources.png' },
                { id: name + '_subscriptions', text: 'Subcriptions (0)', image: 'ApplicationResources/img16/subscriptions.png' },
                { id: name + '_validators', text: 'Validators (0)', image: 'ApplicationResources/img16/validators.png' },
                { id: name + '_views', text: 'Views (0)', image: 'ApplicationResources/img16/views.png' },
                { id: name + '_viewgroups', text: 'View Groups (0)', image: 'ApplicationResources/img16/viewgroups.png' },
                { id: name + '_wfaction', text: 'Workflow actions (0)', image: 'ApplicationResources/img16/wfactions.png' },
                { id: name + '_workflows', text: 'Workflows (0)', image: 'ApplicationResources/img16/workflows.png' },
                { id: name + '_writing', text: 'Writing Model (0)', image: 'ApplicationResources/img16/writingmodel.png' },
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
