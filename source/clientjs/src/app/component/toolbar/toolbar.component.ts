import { Component, Input, SimpleChange, OnInit, OnChanges, ViewChild, ChangeDetectorRef } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { eWorkAreaType } from '../../model/interfaz/enums/eworkareatype';
import { DxTabsComponent, DxTabPanelComponent } from 'devextreme-angular';
@Component(
    {
        selector: 'app-toolbar',
        templateUrl: './toolbar.component.html',
    }
)

export class ToolbarComponent implements OnChanges {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() panels: Array<PanelToolbar>;
    @ViewChild('tabPanel') tabpanel: DxTabPanelComponent;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public index: number;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private changedetector: ChangeDetectorRef) {
        this.index = 0;
    }
    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        if (this.panels.length > 0) {
            const count = this.panels.findIndex(p => p.type !== eWorkAreaType.None);
            if (count !== undefined && count !== -1) {
                if (this.tabpanel.instance !== undefined) {
                    this.index = count;
                }
            } else{
                this.index = 0;
            }
        }
    }

}
