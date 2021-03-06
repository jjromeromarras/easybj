import { Component, Input, Output, EventEmitter, ViewChild } from '@angular/core';
import { DxDataGridComponent } from 'devextreme-angular';

@Component({
    selector: 'app-viewgrid',
    templateUrl: './viewgrid.component.html',

})
export class ViewGridComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() gridDataSource: any;
    @Input() columnDefs: any;
    @Output() selectionChange = new EventEmitter<any>();


    @ViewChild('viewListGrid') gridControl: DxDataGridComponent;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private getKeyRowsSelected(): any {
        const keys = [];
        this.gridControl.instance.getVisibleRows().forEach(r => {
            if (r.isSelected) {
                keys.push(r.key);
            }
        })
        return keys;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onSelectionChanged(event) {
        this.selectionChange.emit(this.getKeyRowsSelected());
    }
}