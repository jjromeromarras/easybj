import { Injectable } from '@angular/core';
import { Application } from '../model/application/application';
import { UserSession } from '../model/interfaz/usersession';
import { Language } from '../model/organization/language';
import { eTraceLevel } from '../model/interfaz/enums/eTraceLevel';
import { EnviromentData } from '../model/interfaz/utils/enviroment';


declare var defaultURL: string;
declare var logLevel: string;
declare var maxResults: number;
declare var webApiService: string;
declare var enabledTelemetry: boolean;

@Injectable()
export class Config {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Configuration paramaters
    private host = defaultURL;
    private urlbase = ''; // Parameter URL base
    private logLevelValue = logLevel;
    private logLevelNumber: eTraceLevel;
    private webApiServiceName = webApiService;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public session: UserSession;
    public enviromentdata: EnviromentData;
    public applications: Array<Application>;
    public currentapp: Application;
    public languages: Array<Language>;


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor() {
        this.applications = new Array<Application>();
        this.languages = new Array<Language>();
        this.session = new UserSession();
        this.currentapp = undefined;
        this.host = this.generateWebApiUrl(document.location);
        console.debug('Connected to WebApiService: ' + this.host);
        this.urlbase = this.host + 'web/'; // Parameter URL base
        this.logLevelNumber = this.parseLogLevel(this.logLevelValue);
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

    public getURLBase(): string {
        return this.urlbase;
    }

    public getLogLevel(): eTraceLevel {
        return this.logLevelNumber;
    }

    public parseLogLevel(logLevelValue: string): eTraceLevel {
        switch (logLevelValue) {
            case "Debug":
                return eTraceLevel.Debug;
            case "Info":
                return eTraceLevel.Info;
            case "Warn":
                return eTraceLevel.Warn;
            case "Error":
                return eTraceLevel.Error;
            default:
                return eTraceLevel.Info;
        }
    }

    public setSession(session: UserSession, enviromentdata: EnviromentData) {
        this.session = session;
        this.enviromentdata = enviromentdata;
        sessionStorage.setItem('UserConfig', JSON.stringify(this.enviromentdata));
    }

    public userIsLogged(): boolean {
        let session = this.getSession();
        // In browser refresh, sometimes, the session is lost. The culture is required for webapi requests.
        return session.culture != null && session.getAccessTokenResponse() != null;
    }

    public createEmptyConfig() {
        this.session = new UserSession();
        this.enviromentdata = new EnviromentData();
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    private generateWebApiUrl(location: Location): string {
        if (this.host == undefined || this.host == "") {
            let baseHost = this.parseLocation(location);
            if (this.webApiServiceName == undefined || this.webApiServiceName == '') {
                return baseHost;
            } else {
                return baseHost + this.webApiServiceName + '/';
            }
        } else {
            return this.host;
        }
    }

    private parseLocation(location: Location): string {
        let url = location.href;
        if (url.endsWith('smartui' + location.search)) {
            url = location.href.replace('smartui' + location.search, ''); // Clean parameters smartui?xxx=yyy&...
        } else {
            url = location.href.replace(location.search, ''); // Clean parameters ?xxx=yyy&...
        }
        url = this.parseLocationHost(url);
        return url;
    }

    private parseLocationHost(url: string): string {
        if (url.endsWith('/')) {
            url = url.slice(0, -1);
        }

        url = url.substring(0, url.lastIndexOf("/"));
        return url + '/';
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // URL METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Login
    public get URL_LOGINGETRESORCE(): string { return this.getURLBase() + 'login/GetResourceApplication'; }
    public get URL_LOGIN(): string { return this.getURLBase() + 'setlogin'; }
    public get URL_LOGINGETLANGUAGES(): string { return this.getURLBase() + 'login/getlanguages'; }

    // Trace
    public get URL_TRACEMANAGER(): string { return this.getURLBase() + 'settrace'; }


}
