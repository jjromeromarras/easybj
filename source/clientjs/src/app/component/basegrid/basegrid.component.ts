import { Component, Input, Output, EventEmitter, OnChanges, SimpleChange, OnDestroy } from '@angular/core';
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

export class BaseGridComponent implements OnChanges, OnDestroy {
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
        this.subscriber = undefined;
        this.registerTypeBroadcast();
    }
    ngOnDestroy() {
        if (this.subscriber != undefined) {
            this.subscriber = undefined;        
        }
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
        if (this.subscriber === undefined) {
            const me = this;
            this.subscriber = this.messageeventservice.on<any>('addMenuComponent')
                .subscribe(message => {
                    if (message === me.type) {
                        me.messageeventservice.broadcast('addMenuGroup', me.pages);
                    }
                });
        }


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