import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-viewgrid',
    templateUrl: './viewgrid.component.html',

})
export class ViewGridComponent  {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() gridDataSource: any;
    @Input() columnDefs: any;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onSelectionChanged(event){

    }
}