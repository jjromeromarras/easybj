import { Component, Input, SimpleChange } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
import action_sheet from 'devextreme/ui/action_sheet';
import { ActionToolbar } from '../../model/interfaz/toolbar/actiontoolbar';
@Component(
    {
        selector: 'app-toolbargroup',
        templateUrl: './toolbargroup.component.html',
    }
)

export class ToolbarGroupComponent {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() group: GroupActionToolbar;


    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
    }

    onClick(action: ActionToolbar){
        action.executeAction(null);
    }
}