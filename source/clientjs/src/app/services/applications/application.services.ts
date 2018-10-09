import { Injectable } from "@angular/core";
import { Config } from "../config.service";
import { Application } from "../../model/application/application";
import { constantsMsg } from "../../model/common/constantsMsg";


@Injectable()
export class ApplicationService {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config) {
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public AddApplication(app: Application): string {
        const result = this.CheckApplication(app);
        if (result === constantsMsg.NOERROR) {
            this.config.applications.push(app);
        }
        return result;
    }

    public EditApplication(app: Application): string {
        if (this.config.currentapp !== undefined) {
            const result = this.CheckApplication(app);
            return result;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    public RemoveApplication(app: Application): string {
        if (this.config.currentapp !== undefined) {
            this.config.applications = this.config.applications.filter(p => p.guid !== app.guid);
            this.config.currentapp = undefined;
            return constantsMsg.NOERROR;
        }
        return constantsMsg.GENERICERROR + ' There is not an application selected';
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHOD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private CheckApplication(app: Application): string {
        if (!this.CheckApplicationName(app)) {
            return constantsMsg.DUPLICATENAME;
        }
        return constantsMsg.NOERROR;
    }
    private CheckApplicationName(app: Application): boolean {
        // Check name unique
        return this.config.applications.findIndex(p => p.name.value === app.name.value && p.guid !== app.guid) === -1;
    }
}