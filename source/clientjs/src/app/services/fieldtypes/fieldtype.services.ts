import { Injectable } from "@angular/core";
import { Config } from "../config.service";
import { constantsMsg } from "../../model/common/constantsMsg";
import { FieldType } from "../../model/application/field/fieldtype";
import { CheckStatus } from "../../model/common/checkstatus";
import { BroadcasterService } from "ng-broadcaster";

@Injectable()
export class FieldTypeService {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public Add(fieldtype: FieldType): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckViewGroup(fieldtype);
            if (result == constantsMsg.NOERROR) {
                this.config.currentapp.fieltypes.push(fieldtype);
                fieldtype.checkStatus = CheckStatus.Default;
                this.messageeventservice.broadcast('onNewApplication');
            }
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public Edit(fieldtype: FieldType): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckViewGroup(fieldtype);
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public Remove(fieldtype: FieldType): string {
        if (this.config.currentapp !== undefined) {
            this.config.currentapp.fieltypes = this.config.currentapp.fieltypes.filter(p => p.guid != fieldtype.guid);
            this.messageeventservice.broadcast('onNewApplication');
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public CheckIn(fieldtype: FieldType): string {
        if (this.config.currentapp !== undefined) {
            fieldtype.checkStatus = CheckStatus.Default;
            fieldtype.lockedBy = '';
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public CheckOut(fieldtype: FieldType): string {
        if (this.config.currentapp !== undefined) {
            if (fieldtype.checkStatus === CheckStatus.Default) {
                fieldtype.checkStatus = CheckStatus.Editable;
                fieldtype.lockedBy = this.config.session.user;
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
    private CheckViewGroup(fieldtype: FieldType): string {
        if (!this.CheckViewGroupName(fieldtype)) {
            return constantsMsg.DUPLICATENAME;
        }
        return constantsMsg.NOERROR;
    }
    private CheckViewGroupName(fieldtype: FieldType): boolean {
        // Check name unique
        return this.config.currentapp.fieltypes.findIndex(p => p.name.value == fieldtype.name.value && p.guid != fieldtype.guid) == -1;
    }
}