import { Component, Input, SimpleChange, OnChanges } from '@angular/core';
import { GroupActionToolbar } from '../../model/interfaz/toolbar/groupactiontoolbar';
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


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    onClick(action: ActionToolbar) {
        action.executeAction(null);
    }

    onVisible(action: ActionToolbar): boolean {
        if (action.visibleAction !== undefined) {
            return action.visibleAction(null);
        }
        return true;
    }
}
