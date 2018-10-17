import { Component, Input, Output, EventEmitter, SimpleChange, OnChanges } from '@angular/core';
import { PanelToolbar } from '../../model/interfaz/toolbar/paneltoolbar';
import { Config } from '../../services/config.service';
import { eViewModes } from '../../model/interfaz/enums/eviewmodes';
import { ViewPanel } from '../../model/interfaz/view/controls/viewpanel';
import { ViewHelper } from '../../model/interfaz/utils/viewhelper';
import { eViewFieldTypes } from '../../model/interfaz/enums/eviewfieldtypes';
import { eViewControlTypes } from '../../model/interfaz/enums/eviewcontroltypes';
import { constantsMsg } from '../../model/common/constantsMsg';
import { FieldType } from '../../model/application/field/fieldtype';
import { FieldTypeService } from '../../services/fieldtypes/fieldtype.services';
import { Lov } from '../../model/interfaz/view/controls/lov';
import { Stereotype } from '../../model/application/field/stereotype';
import { ViewFieldLov } from '../../model/interfaz/view/controls/viewfieldlov';


@Component(
    {
        selector: 'app-fieldtype',
        templateUrl: './fieldtype.component.html',
    }
)

export class FieldTypeComponent implements OnChanges {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPU METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @Output() close = new EventEmitter();
    @Input() title: string;
    @Input() viewMode: eViewModes;
    @Input() selected: FieldType;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public pages: Array<PanelToolbar>;
    public auto: string;
    public visible: boolean;
    public viewPanels: Array<ViewPanel>;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private service: FieldTypeService) {
        this.auto = 'auto';
        this.viewMode = eViewModes.Edit;
        this.visible = true;

    }

    ngOnChanges(changes: { [propkey: string]: SimpleChange }) {
        if (this.selected !== undefined) {
            this.SetViewEdit();
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private SetViewEdit() {
        this.viewPanels = new Array<ViewPanel>();
        const viewpanel: ViewPanel = new ViewPanel();
        viewpanel.colSpan = 4;

        ViewHelper.createViewField('Name', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 1, 2, true,
            viewpanel, this.selected.name);
        ViewHelper.createViewField('Description', eViewFieldTypes.TextBox, eViewControlTypes.ViewField, 2, 2, false,
            viewpanel, this.selected.description);
        const vftype = ViewHelper.createViewField('Type', eViewFieldTypes.DropDownList, eViewControlTypes.ViewField, 3, 1, true,
            viewpanel, this.selected.stereotype);
        vftype.allowSearch = true;
        this.setStereotype(vftype.viewFieldLOV);
        ViewHelper.createViewField('Entity type', eViewFieldTypes.AutoCompleteLookup, eViewControlTypes.ViewField, 4, 1, false,
            viewpanel, this.selected.description);

        this.viewPanels.push(viewpanel);
    }

    private setStereotype(vf: ViewFieldLov) {
        vf.listOfValues.push(this.createLov(Stereotype.String, 'String'));
        vf.listOfValues.push(this.createLov(Stereotype.Boolean, 'Boolean'));
        vf.listOfValues.push(this.createLov(Stereotype.Date, 'Date'));
        vf.listOfValues.push(this.createLov(Stereotype.Decimal, 'Decimal'));
        vf.listOfValues.push(this.createLov(Stereotype.DateTime, 'DateTime'));
        vf.listOfValues.push(this.createLov(Stereotype.Integer, 'Integer'));
        vf.listOfValues.push(this.createLov(Stereotype.List, 'List'));
        vf.listOfValues.push(this.createLov(Stereotype.NullableBoolean, 'NullableBoolean'));
        vf.listOfValues.push(this.createLov(Stereotype.NullableDate, 'NullableDate'));
        vf.listOfValues.push(this.createLov(Stereotype.NullableDateTime, 'NullableDateTime'));
        vf.listOfValues.push(this.createLov(Stereotype.NullableDecimal, 'NullableDecimal'));
        vf.listOfValues.push(this.createLov(Stereotype.NullableGuid, 'NullableGuid'));
        vf.listOfValues.push(this.createLov(Stereotype.NullableInteger, 'NullableInteger'));
        vf.listOfValues.push(this.createLov(Stereotype.NullableTime, 'NullableTime'));
        vf.listOfValues.push(this.createLov(Stereotype.ObjectDictionary, 'ObjectDictionary'));
        vf.listOfValues.push(this.createLov(Stereotype.Record, 'Record'));
        vf.listOfValues.push(this.createLov(Stereotype.Time, 'Time'));
    }

    private createLov(value: any, displayValue: any): Lov {
        var lov = new Lov();
        lov.value = value;
        lov.displayValue = displayValue;
        return lov;
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onHiding($event) {
        this.visible = false;
        this.close.emit();
    }

    onClickedCancel() {
        this.viewMode = eViewModes.Read;
        this.selected = undefined;
        this.onHiding(null);
    }

    onClickedSave() {
        let save = constantsMsg.NOERROR;
        if (this.viewMode === eViewModes.New) {
            save = this.service.Add(this.selected);
        } else {
            save = this.service.Edit(this.selected);
        }

        if (save !== constantsMsg.NOERROR) {
            alert(save);
        } else {
            this.onClickedCancel();
        }
    }
}