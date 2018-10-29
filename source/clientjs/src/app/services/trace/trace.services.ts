import { Http, RequestOptions } from '@angular/http';
import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Config } from '../config.service';
import { BroadcasterService } from 'ng-broadcaster';
import { WebAPIHelper } from '../../model/interfaz/utils/webapihelper';
import { TraceParameters } from '../../model/interfaz/utils/traceparameters';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class TraceServices {
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR  
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private http: HttpClient, private config: Config, private messageEventService: BroadcasterService) {

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC METHOD
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public logConsoleError(msg: string) {
        msg = "[" + new Date().toString() + "]  " + msg;
        console.error(msg)
    }

    public logConsoleDebug(msg: string) {
        msg = "[" + new Date().toString() + "]  " + msg;
        console.debug(msg);
    }

    public logConsoleInfo(msg: string) {
        msg = "[" + new Date().toString() + "]  " + msg;
        console.info(msg);
    }
    public logConsoleWarn(msg: string) {
        msg = "[" + new Date().toString() + "]  " + msg;
        console.warn(msg);
    }
    public logError(msg: string) {
        this.logConsoleError(msg);
        this.sendTrace(msg, 'Error');
    }

    public logException(exceptionText: any, userFriendlyError: string) {
        this.logConsoleError(exceptionText);
        if (exceptionText.stack != undefined) {
            if (exceptionText.stack.substring('RangeError: Maximum call stack size exceeded') == undefined) {
                this.messageEventService.broadcast('logException|' + userFriendlyError);
                this.sendTrace(exceptionText, 'Error');
            }
        } else {
            this.messageEventService.broadcast('logException|' + userFriendlyError);
            this.sendTrace(exceptionText, 'Error');
        }
    }

    public logDebug(msg: string) {
        this.logConsoleDebug(msg);
        this.sendTrace(msg, 'Debug');
    }

    public logInfo(msg: string) {
        this.logConsoleInfo(msg);
        this.sendTrace(msg, 'Info');
    }
    public logWarn(msg: string) {
        this.logConsoleWarn(msg);
        this.sendTrace(msg, 'Warn');
    }
    public logTime(msg: string) {
        console.time(msg);
    }

    public logTimeEnd(msg: string) {
        console.timeEnd(msg);
        this.sendTrace(msg, 'Info');
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // set Trace to WEBAPI
    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public sendTrace(msg: string, level: string): Promise<any> {
        msg = "[" + new Date().toString() + "]  " + msg;
        let logTraceLevel = this.config.getLogLevel();
        let currentLevel = this.config.parseLogLevel(level);
        if (currentLevel >= logTraceLevel) {
            let data: TraceParameters = new TraceParameters();
            if (this.config.getSession() != undefined) {
                data.msg = `[User '${this.config.getSession().user}'] : ${msg}`;
            } else {
                data.msg = `[User undefined] : ${msg}`;
            }
            data.tracelevel = level;

            let body = JSON.stringify(data);
            let headers = WebAPIHelper.createPostHeaders();
            return this.http.post(this.config.URL_TRACEMANAGER, body, { headers: headers }).toPromise();
        } else {
            return Promise.resolve(null);
        }
    }
}