import { Injectable } from '@angular/core';
import { Application } from '../model/application/application';
import { UserSession } from '../model/interfaz/usersession';

@Injectable()
export class Config {
    session: UserSession;
    applications: Array<Application>
    currentapp: Application;

    constructor(){
        this.applications = new Array<Application>();
        this.session = new UserSession();
        this.currentapp = undefined;
    }

     ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public getSession(): UserSession {
        if (this.session == null) {
            this.session = new UserSession();
        }
        return this.session;
    }

}