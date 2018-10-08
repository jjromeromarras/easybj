import { Injectable } from '@angular/core';
import { ViewPanel } from '../view/controls/viewpanel';
import { ViewControl } from '../view/controls/viewcontrol';
import { ArrayUtils } from './arrayutils';
import { eViewControlTypes } from '../enums/eviewcontroltypes';
import { ViewPageControl } from '../view/controls/viewpagecontrol';
import { ViewField } from '../view/controls/viewfield';

@Injectable()
export class ViewHelper {

    public static createViewField(title: string, vftype: string, type: string, sequence: number, colSpan: number,
        isRequired: boolean, panel: ViewPanel, data: any) {

        const vf = new ViewField();
        vf.title = title;
        vf.isRequired = isRequired;
        vf.viewFieldType = vftype;
        vf.type = type;
        vf.sequence = sequence;
        vf.colSpan = colSpan;
        vf.dataobj = data;
        panel.controls.push(vf);
        panel.viewFields.push(vf);

    }
    public static getGridColumnDefinition(title: string, hidecol: Boolean, dataFieldName: String,
        allowResizing: boolean, allowFiltering: boolean, allowSorting: boolean): any {
        const columnDefinition: any = {
            caption: title,
            dataField: dataFieldName,
            visible: !hidecol,
            allowResizing: true,
            allowFiltering: allowFiltering,
            allowSorting: allowSorting,
            showInColumnChooser: true
        };

        return columnDefinition;
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Get ViewControl with visibility condiction script
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    public static getViewControlsInViewPanels(viewPanels: Array<ViewPanel>): Array<ViewControl> {
        let result: Array<ViewControl> = [];
        result = viewPanels;
        viewPanels.sort(ArrayUtils.sortBySequence).forEach(c => {
            if (c != null) {
                result = result.concat(this.getViewControlsInViewPanel(c));
            }
        });
        return result;
    }


    public static getViewControlsInViewPanel(panel: ViewPanel): Array<ViewControl> {
        let result: Array<ViewControl> = [];
        panel.controls.sort(ArrayUtils.sortBySequence).forEach(c => {
            if (c != null) {
                result.push(c);
                // Alta
                switch (c.type) {
                    case eViewControlTypes.Panel:
                    case eViewControlTypes.PanelPage:
                        result = result.concat(this.getViewControlsInViewPanel(<ViewPanel>c));
                        break;
                    case eViewControlTypes.PageControl:
                        result = result.concat(this.getViewControlsInViewPageControl(<ViewPageControl>c));
                        break;
                }
            }
        });

        return result;
    }

    public static getViewControlsInViewPageControl(viewpage: ViewPageControl): Array<ViewControl> {
        let result: Array<ViewControl> = [];
        viewpage.pages.sort(ArrayUtils.sortBySequence).forEach(p => {
            if (p != null) {
                result.push(p);
                result = result.concat(this.getViewControlsInViewPanel(p));
            }
        });
        return result;
    }

}