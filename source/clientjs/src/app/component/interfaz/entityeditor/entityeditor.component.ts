import { Component, Input } from '@angular/core';
import { ViewPanel } from '../../../model/interfaz/view/controls/viewpanel';
import { eViewModes } from '../../../model/interfaz/enums/eviewmodes';
import { Config } from '../../../services/config.service';
@Component({
    selector: 'app-entity-editor',
    templateUrl: './entityeditor.component.html',
})

export class EntityEditorComponent  {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() viewpanels: Array<ViewPanel>;
    @Input() viewMode: eViewModes;
    @Input() fullscreen: boolean;
    @Input() selected: Array<any>;
    @Input() savedAndContinue: boolean;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR>
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config) {
    }

   
    
}