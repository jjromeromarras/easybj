import { Injectable } from '@angular/core';
import { Config } from '../config.service';
import { BroadcasterService } from 'ng-broadcaster';
import { Dialog } from '../../model/application/dialogs/dialogs';
import { constantsMsg } from '../../model/common/constantsMsg';
import { CheckStatus } from '../../model/common/checkstatus';


@Injectable()
export class DialogsService {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Add(obj: Dialog): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckDialog(obj);
            if (result === constantsMsg.NOERROR) {
              //  this.config.currentapp.Dialogs.push(obj);
                obj.checkStatus = CheckStatus.Default;
                this.messageeventservice.broadcast('onNewApplication');
            }
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public Edit(obj: Dialog): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckDialog(obj);
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public Remove(obj: Dialog): string {
        if (this.config.currentapp !== undefined) {
           // this.config.currentapp.Dialogs = this.config.currentapp.Dialogs.filter(p => p.guid !== obj.guid);
           // this.messageeventservice.broadcast('onNewApplication');
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public CheckIn(obj: Dialog): string {
        if (this.config.currentapp !== undefined) {
            obj.checkStatus = CheckStatus.Default;
            obj.lockedBy = '';
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public CheckOut(obj: Dialog): string {
        if (this.config.currentapp !== undefined) {
            if (obj.checkStatus === CheckStatus.Default) {
                obj.checkStatus = CheckStatus.Editable;
                obj.lockedBy = this.config.session.user;
                return constantsMsg.NOERROR;
            } else {
                return constantsMsg.NOTREADONLY;
            }

        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private CheckDialog(obj: Dialog): string {
        if (!this.CheckDialogName(obj)) {
            return constantsMsg.DUPLICATENAME;
        }
        return constantsMsg.NOERROR;
    }
    private CheckDialogName(obj: Dialog): boolean {
        // Check name unique
       // return this.config.currentapp.fieltypes.findIndex(p => p.name.value === obj.name.value && p.guid !== obj.guid) === -1;
       return true;
    }
}