import { Component, Input, SimpleChange, OnChanges, ChangeDetectorRef } from '@angular/core';
import { ViewPanel } from '../../../model/interfaz/view/controls/viewpanel';
import { eViewModes } from '../../../model/interfaz/enums/eviewmodes';
import { eViewControlTypes } from '../../../model/interfaz/enums/eviewcontroltypes';
@Component({
    selector: 'app-viewpanel',
    templateUrl: './viewpanel.component.html',

})
export class ViewPanelComponent implements OnChanges {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Input() panel: ViewPanel;
    @Input() colSpanParent: number;
    @Input() fullscreen: boolean;
    @Input() viewMode: eViewModes;
    @Input() showTitle: boolean;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public modeNew: boolean;
    eViewControlTypes = eViewControlTypes;  // Access to enum from HTML

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private colNumber: number;
    public rowsControl: number[];

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor() {
        this.modeNew = false;
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NG METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        for (let propName in changes) {
            if (propName == 'panel') {
                this.panel = changes[propName].currentValue;
            }

        }
        if (this.fullscreen) {
            // In fullscreen mode the number of columns is double than simple mode
            this.colNumber = 2 * this.panel.colCount;
        } else {
            this.colNumber = this.panel.colCount;
        }
        this.setControlPositions();
        this.panel.currentVisible = true;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private setControlPositions() {
        this.panel.controls = this.panel.controls.sort((n1, n2) => {
            let sq1 = n1.currentVisible ? n1.sequence : n1.sequence * 1000;
            let sq2 = n2.currentVisible ? n2.sequence : n2.sequence * 1000;
            if (sq1 > sq2) {
                return 1;
            } else {
                return -1;
            }
        });

        let index = 0;
        let rownumber = 1;
        this.rowsControl = [];
        this.panel.controls.forEach(c => {
            if (c.currentVisible) {
                c.controlClass = this.controlClass(c);
                c.rownumber = rownumber;
                if (c.type == eViewControlTypes.Panel && this.fullscreen) {
                    index = index + (c.colSpan * 2);
                } else {
                    index = index + c.colSpan;
                }
                if (index >= this.colNumber) {
                    this.rowsControl.push(rownumber);
                    rownumber++;
                    index = 0;
                }
            } else {
                c.rownumber = -1;
            }
        });

        if (this.rowsControl.find(r => r == rownumber) == undefined) {
            this.rowsControl.push(rownumber);
        }
    }

    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /**
     * Calculates the bootstrap class to apply to current control
     * @param control Current control
     */
    controlClass(control: any): string {
        if (control.type === eViewControlTypes.Panel) {
            // View panels
            if (control.colSpan === 1 && this.panel.colCount > 1) {
                return 'col-md-6';
            } else if ((control.colSpan > 1 || this.panel.colCount === 1)) {
                return 'col-md-12';
            }
        } else {
            // Other controls than view panels
            if (control.colSpan === 1) {
                if (control.type === eViewControlTypes.PageControl) {
                    // Page control
                    return 'col-md-12';
                } else if (control.type !== eViewControlTypes.ViewField || (!this.fullscreen)) {
                    // Viewfields or controls in not fullscreen mode
                    if (control.type === eViewControlTypes.ViewField || control.type === eViewControlTypes.DetailPanel
                        || control.type === eViewControlTypes.Gauge || control.type === eViewControlTypes.Graph) {
                        // Viewfields
                        return this.viewFieldBootstrapMDCalculator(control.colSpan, this.panel.colCount);
                    } else {
                        return 'col-md-6';
                    }
                } else {
                    if (control.type === eViewControlTypes.ViewField || control.type === eViewControlTypes.DetailPanel
                        || control.type === eViewControlTypes.Gauge || control.type === eViewControlTypes.Graph) {
                        // Viewfields
                        return this.viewFieldBootstrapMDCalculator(control.colSpan, this.panel.colCount);
                    } else {
                        return 'col-md-3';
                    }
                }
            } else if (control.colSpan > 1) {
                if (control.type !== eViewControlTypes.ViewField || (!this.fullscreen)) {
                    if (control.type === eViewControlTypes.ViewField || control.type === eViewControlTypes.DetailPanel
                        || control.type === eViewControlTypes.Gauge || control.type === eViewControlTypes.Graph ||
                        control.type === eViewControlTypes.ViewFieldCustomUserControl) {
                        // Viewfields
                        return this.viewFieldBootstrapMDCalculator(control.colSpan, this.panel.colCount);
                    } else {
                        return 'col-md-12';
                    }
                } else {
                    if (control.type === eViewControlTypes.ViewField || control.type === eViewControlTypes.DetailPanel
                        || control.type === eViewControlTypes.Gauge || control.type === eViewControlTypes.Graph) {
                        // Viewfields
                        return this.viewFieldBootstrapMDCalculator(control.colSpan, this.panel.colCount);
                    } else {
                        return 'col-md-6';
                    }
                }
            }
        }
    }
    /**
     * Given the colspan and the parent panel num of columns, returns the
     * bootstrap class to apply to show a VIEWFIELD
     * @param colspan Control span
     * @param colCount Control's parent number of columns
     */
    viewFieldBootstrapMDCalculator(colspan: number, colCount: number) {
        let className = 'col-md-';
        if (this.fullscreen) {
            // In fullscreen mode the number of columns is double than simple mode
            colCount = 2 * colCount;
        }
        switch (colCount) {
            case 1:
                // Only one column    
                return className + '12';
            case 2:
                // Two columns    
                switch (colspan) {
                    case 1:
                        return className + '6';
                    case 2:
                        return className + '12';
                    default:
                        return className + '6';
                }
            case 3:
                // Three columns    
                switch (colspan) {
                    case 1:
                        return className + '4';
                    case 2:
                        return className + '8';
                    case 3:
                        return className + '12';
                    default:
                        return className + '4';
                }
            case 4:
                // Four columns    
                switch (colspan) {
                    case 1:
                        return className + '3';
                    case 2:
                        return className + '6';
                    case 3:
                        return className + '9';
                    case 4:
                        return className + '12';
                    default:
                        return className + '3';
                }
            case 6:
                // Six columns (3 on full screen)
                switch (colspan) {
                    case 1:
                        return className + '2';
                    case 2:
                        return className + '4';
                    case 3:
                        return className + '6';
                    case 4:
                        return className + '8';
                    case 5:
                        return className + '10';
                    case 6:
                        return className + '12';
                    default:
                        return className + '2';
                }
            default:
                return className + '6';
        }
    }
}