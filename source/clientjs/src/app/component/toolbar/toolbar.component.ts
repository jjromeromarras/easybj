import { Component, Input, SimpleChange } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
@Component(
    {
        selector: 'app-toolbar',
        templateUrl: './toolbar.component.html',
    }
)

export class ToolbarComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() panels: Array<PanelToolbar>;
}
