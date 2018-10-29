import { Injectable } from "@angular/core";
import { Config } from "../config.service";
import { HttpClient } from "@angular/common/http";
import { WebAPIHelper } from "../../model/interfaz/utils/webapihelper";
import { map } from 'rxjs/operators/map'
import { catchError } from 'rxjs/operators/catchError'
import { ErrorHandlerService } from "../errorHandler/errorHandler.service";
import { Observable } from "rxjs";
import { Login } from "../../model/application/login/login";


@Injectable()
export class LoginService {

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(public config: Config, private httpclient: HttpClient, private errorHandler: ErrorHandlerService) {

    }


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Get Languages
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public getLanguages(): any {
        let headers = WebAPIHelper.createGetHeaders();
        return this.httpclient.get(this.config.URL_LOGINGETLANGUAGES, { headers: headers })
            .pipe(
                map(this.extractData),
                catchError(this.errorHandler.handleError.bind(this))
            );
    }

    private extractData(res: Response): any {
        return res.json();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // Login
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public authenticate(login: Login): Observable<any> {
        let body = JSON.stringify(login);
        let headers = WebAPIHelper.createPostHeaders();
        return this.httpclient.post(this.config.URL_LOGIN, body, { headers: headers })
            .pipe(        
                catchError(this.errorHandler.handleError.bind(this))
            );
    }
}