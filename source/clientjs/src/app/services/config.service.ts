import { Injectable } from '@angular/core';
import { Application } from '../model/application/application';
import { UserSession } from '../model/interfaz/usersession';
import { Language } from '../model/organization/language';

@Injectable()
export class Config {
    session: UserSession;
    applications: Array<Application>;
    currentapp: Application;
    languages: Array<Language>;

    constructor() {
        this.applications = new Array<Application>();
        this.languages = new Array<Language>();
        this.session = new UserSession();
        this.currentapp = undefined;

        const language = new Language();
        language.name.value = 'Español';
        language.countryCode.value = 'es';
        this.languages.push(language);

        const b = new Language();
        b.name.value = 'English';
        b.countryCode.value = 'en';
        this.languages.push(b);
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
