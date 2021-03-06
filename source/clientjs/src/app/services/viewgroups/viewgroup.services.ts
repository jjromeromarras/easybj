import { Injectable } from "@angular/core";
import { Config } from "../config.service";
import { ViewGroup } from "../../model/application/views/viewgroups";
import { constantsMsg } from "../../model/common/constantsMsg";
import { BroadcasterService } from "ng-broadcaster";

@Injectable()
export class ViewGroupService {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private messageeventservice: BroadcasterService) {
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public AddViewGroup(viewgroup: ViewGroup): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckViewGroup(viewgroup);
            if (result == constantsMsg.NOERROR) {
                this.config.currentapp.viewgroups.push(viewgroup);
                this.messageeventservice.broadcast('onNewApplication');
            }
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public EditViewGroup(viewgroup: ViewGroup): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckViewGroup(viewgroup);
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public RemoveViewGroup(viewgroup: ViewGroup): string {
        if (this.config.currentapp !== undefined) {
            this.config.currentapp.viewgroups = this.config.currentapp.viewgroups.filter(p => p.guid != viewgroup.guid);
            this.messageeventservice.broadcast('onNewApplication');
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private CheckViewGroup(viewgroup: ViewGroup): string {
        if (!this.CheckViewGroupName(viewgroup)) {
            return constantsMsg.DUPLICATENAME;
        }
        return constantsMsg.NOERROR;
    }
    private CheckViewGroupName(viewgroup: ViewGroup): boolean {
        // Check name unique
        return this.config.currentapp.viewgroups.findIndex(p => p.name.value == viewgroup.name.value && p.guid != viewgroup.guid) == -1;
    }
}