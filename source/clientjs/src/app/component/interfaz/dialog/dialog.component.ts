import { Component, ViewChild, Input, Output, EventEmitter, ChangeDetectorRef, OnInit, AfterViewInit } from '@angular/core';
import { DxPopupComponent } from 'devextreme-angular';
import { DialogResponse } from './dialogconstants';
import { Config } from '../../../services/config.service';
import { ActionConfirmationModes } from './ActionConfirmationModes';

@Component({
    selector: 'app-dialog',
    templateUrl: './dialog.component.html',

})


export class DialogComponent implements OnInit, AfterViewInit {
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // INPUT/OUTPUT FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    @ViewChild('dialogPanel') panel: DxPopupComponent;
    @Input() message: string;
    @Input() title: string;
    @Input() dialogType;
    @Output() onCloseDialog = new EventEmitter<DialogResponse>();

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private showPopup: boolean;
    private rtlEnabled: boolean;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public buttonOkVisible: boolean;
    public buttonYesVisible: boolean;
    public buttonNoVisible: boolean;
    public buttonCancelVisible: boolean;
    public buttonExitVisible: boolean;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config, private changeDetectorRef: ChangeDetectorRef) {
        this.showPopup = true;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // NG METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ngOnInit() {
        this.rtlEnabled = this.config.getSession().isRTL;
    }
    ngAfterViewInit() {
        this.changeDetectorRef.detectChanges();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private closeDialog(response: DialogResponse): void {
        this.close(response);
    }

    private close(response: DialogResponse) {
        this.showPopup = false;
        this.onCloseDialog.emit(response);
        this.panel.instance.hide();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    /** Click on 'Exit' button */
    public onExitButton($event): void {
        this.closeDialog(DialogResponse.Ok);
    }

    /** Click on 'Yes' button */
    public onYesButton($event): void {
        this.closeDialog(DialogResponse.Yes);
    }

    /** Click on 'No' button */
    public onNoButton($event): void {
        this.closeDialog(DialogResponse.No);
    }

    /** Click on 'Cancel' button */
    public onCancelButton($event): void {
        this.closeDialog(DialogResponse.Cancel);
    }
    /** Click on 'Close' button */
    public onCloseButton($event): void {
        this.showPopup = false;
        this.panel.instance.hide();
    }

    public onShown($event) {
        this.buttonYesVisible = (this.dialogType === ActionConfirmationModes.YesNo)
            || (this.dialogType === ActionConfirmationModes.YesNoCancel);
        this.buttonNoVisible = (this.dialogType === ActionConfirmationModes.YesNo)
            || (this.dialogType === ActionConfirmationModes.YesNoCancel);
        this.buttonCancelVisible = (this.dialogType === ActionConfirmationModes.YesNoCancel);
        this.buttonExitVisible = (this.dialogType === ActionConfirmationModes.None);
    }

}
