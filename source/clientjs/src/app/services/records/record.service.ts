import { Injectable } from '@angular/core';
import { Config } from '../config.service';
import { constantsMsg } from '../../model/common/constantsMsg';
import { CheckStatus } from '../../model/common/checkstatus';
import { BroadcasterService } from 'ng-broadcaster';
import { Record } from '../../model/application/record/record';

@Injectable()
export class RecordService {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Add(obj: Record): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckRecord(obj);
            if (result === constantsMsg.NOERROR) {
                this.config.currentapp.records.push(obj);
                obj.checkStatus = CheckStatus.Default;
                this.messageeventservice.broadcast('onNewApplication');
            }
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public Edit(obj: Record): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckRecord(obj);
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public Remove(obj: Record): string {
        if (this.config.currentapp !== undefined) {
            this.config.currentapp.records = this.config.currentapp.records.filter(p => p.guid !== obj.guid);
            this.messageeventservice.broadcast('onNewApplication');
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public CheckIn(obj: Record): string {
        if (this.config.currentapp !== undefined) {
            obj.checkStatus = CheckStatus.Default;
            obj.lockedBy = '';
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public CheckOut(obj: Record): string {
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
    private CheckRecord(obj: Record): string {
        if (!this.CheckRecordName(obj)) {
            return constantsMsg.DUPLICATENAME;
        }
        return constantsMsg.NOERROR;
    }
    private CheckRecordName(obj: Record): boolean {
        // Check name unique
        return this.config.currentapp.records.findIndex(p => p.name.value === obj.name.value && p.guid !== obj.guid) === -1;
    }
}