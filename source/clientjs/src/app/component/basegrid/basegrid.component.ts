import { Component, Input, Output, EventEmitter, OnChanges, SimpleChange } from '@angular/core';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { DialogResponse } from '../interfaz/dialog/dialogconstants';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { BroadcasterService } from 'ng-broadcaster';
import { forEach } from '@angular/router/src/utils/collection';

@Component(
    {
        selector: 'app-basegrid',
        templateUrl: './basegrid.component.html',
    }
)

export class BaseGridComponent implements OnChanges {
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() datasource: any;
    @Input() title: string;
    @Input() viewMode: eViewModes;
    @Input() showDialog: boolean;
    @Input() dialogTitle: string;
    @Input() message: string;
    @Input() dialogType: any;
    @Input() colData: any[];
    @Input() type: any;
    @Input() pages: Array<PanelToolbar>;
    @Output() closeDialog = new EventEmitter<DialogResponse>();
    @Output() selectionChange = new EventEmitter<any>();
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private subscriber: any;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private messageeventservice: BroadcasterService) {
        this.registerTypeBroadcast();
    }

    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        for (const propName in changes) {
            if (propName === 'pages') {
                this.messageeventservice.broadcast('addMenuGroup', this.pages);
            }
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private registerTypeBroadcast() {
        this.subscriber = this.messageeventservice.on<any>('addMenuComponent')
            .subscribe(message => {
                if (message === this.type) {
                    this.messageeventservice.broadcast('addMenuGroup', this.pages);
                }
            });


    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    onSelectionChange($event) {
        this.selectionChange.emit($event[0]);
    }

    onCloseDialog(e) {
        this.closeDialog.emit(e);
    }

}