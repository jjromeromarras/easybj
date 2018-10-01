import { QueryException } from '../../model/exceptions/queryexceptions';
import { Observable } from 'rxjs';
import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

let me;

@Injectable()
export class ErrorHandlerService {

    constructor() {
        me = this;
    }
    /** Handles service errors */
    public handleError(error: HttpErrorResponse | any): any {
        let errMsg: string;
        if (error instanceof HttpErrorResponse) {
            let ex = error.error;
            if (ex.exceptionMessage != undefined) {
                if ((ex.innerException != undefined && ex.innerException.exceptionType == 'System.UnauthorizedAccessException')
                    || ex.exceptionType == 'System.UnauthorizedAccessException') {                  
                    return Observable.throw(new QueryException(ex.exceptionMessage, true));
                } else {
                    return Observable.throw(error);
                }
            } else {
                return Observable.throw(new QueryException('Connection with server has been lost', false));
            }

        } else {

            errMsg = error.message ? error.message : error.toString();
            return Observable.throw(new QueryException(errMsg, false));
        }
    }
    /** Parses an error */
    public parseError(error: any): QueryException {

        if (error instanceof HttpErrorResponse)
        {
            return new QueryException(error.error.exceptionMessage, false);
        } else if (error instanceof QueryException)
        {
            return <QueryException>error;
        } else{
            <QueryException>error.json()
        }

    }
}