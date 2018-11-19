import { Component, OnInit, Renderer, ElementRef } from '@angular/core';
import { UserSession } from '../../model/interfaz/usersession';
import { Config } from '../../services/config.service';
import { Login } from '../../model/application/login/login';
import { Router } from '@angular/router';
import { LoginService } from '../../services/login/login.services';
import { ErrorHandlerService } from '../../services/errorHandler/errorHandler.service';
import { QueryException } from '../../model/exceptions/queryexceptions';
import { TraceServices } from '../../services/trace/trace.services';
import { EnviromentData } from '../../model/interfaz/utils/enviroment';

@Component(
    {
        selector: 'app-login',
        templateUrl: './login.component.html',
    }
)

export class LoginComponent {


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PUBLIC FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public userName: string;
    public requiredField: string;
    public passwordStr: string;
    public currentTime: any;
    public login: Login;
    public title: string;
    public auto: string;
    public inlineCreationVisible: boolean;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private session: UserSession;
    private enviroment: EnviromentData;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // CONSTRUCTOR FIELDS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    constructor(private config: Config, private element: ElementRef, private renderer: Renderer,
        private router: Router, private loginservice: LoginService, private errorHandler: ErrorHandlerService,
        private tracemanager: TraceServices) {
        this.currentTime = new Date();
        this.login = new Login();
        this.auto = 'auto';
        this.title = 'Login';
    }

    ngAfterViewInit() {
        this.setFocus();
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // PRIVATE METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    private setFocus() {
        //if (this.renderer != null && this.element != null && this.element.nativeElement != null) {
          //  this.renderer.invokeElementMethod(this.element.nativeElement.querySelector('input'), 'focus');
       // }
    }

    private setLogin(data: any) {

        if (data.authinfo.RequestError) {
            let errorMsg = "";
            switch (data.authinfo.requestError.errorDescription) {
                case "LicenseNumUsersExceeded":
                    errorMsg = "NumUsersExceeded";
                    break;
                case "InvalidLicense":
                    errorMsg = "InvalidLicense";
                    break;
                case "InvalidUserPassword":
                    errorMsg = "LoginError";
                    break;
                default:
                    errorMsg = "LoginError";
                    break;
            }
            this.session.errorCode = data.authinfo.RequestError.ErrorCode;
            this.session.errorDescription = data.authinfo.RequestError.ErrorDescription;
            this.tracemanager.logInfo('Execute checkLogin in Login with result: ' + errorMsg);
            alert('Execute checkLogin in Login with result: ' + errorMsg);
            /*this.resourceservice.getResource(errorMsg, this.login.culture, constants.SMARTUI).subscribe(
                datos => {
                    this.setresourceValue(this.resultMessage, datos);
                    this.getLanguages();
                    this.setFocus();
                },
                error => {
                    let exception: QueryException = this.errorHandler.parseError(error);
                    let msg = 'Exception in login.component in setLogin to getResource: ' + exception.exceptionMessage;
                    if (!exception.isUnauthorizedAccessException) {
                        this.tracemanager.logException(msg, exception.exceptionMessage);
                    } else {
                        this.tracemanager.logError(msg);
                    }
                });*/

        } else {
            this.config.createEmptyConfig();
            this.session = new UserSession();
            this.enviroment = new EnviromentData();
            this.session.errorCode = '';
            this.session.errorDescription = '';
            //this.loadingSplash = false;

            this.session.user = data.authinfo.UserName;
            if (data.token != null && data.authinfo.Token != null) {
                this.session.accessTokenResponse = data.token;
                this.enviroment.accessTokenResponse = data.token;
                this.enviroment.internalToken = data.authinfo.Token.AccessToken;
                this.enviroment.refreshToken = data.authinfo.Token.RefreshToken;
                this.session.expirationDate = data.authinfo.Token.ExpirationDate;
                this.session.userId = data.authinfo.UserId;
                // Get grid and forms configuration
            }
            this.session.culture = this.login.culture;
            this.session.isRTL = this.login.isRTL;

            this.config.setSession(this.session, this.enviroment);
        }
        this.checkLogin(this.session);

    }

    private checkLogin(session: UserSession) {
        if (session.accessTokenResponse != null) {
            this.router.navigate(['/easyb'], {});
        }
    }
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // HTML METHODS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    onLogIn(isValid: boolean) {
        if (this.login.user !== '' && this.login.password !== '' && isValid) {
            //this.router.navigate(['/easyb'], {

            //});
            this.loginservice.authenticate(this.login)
                .subscribe(
                    data => this.setLogin(data),
                    error => {
                        let exception: QueryException = this.errorHandler.parseError(error);
                        let msg = 'Exception in login.component in onLogIn: ' + exception.exceptionMessage;
                        if (!exception.isUnauthorizedAccessException) {
                            this.tracemanager.logException(msg, exception.exceptionMessage);
                        } else {
                            this.tracemanager.logError(msg);
                        }
                    });

            //.subscribe(data => {
            //  this.router.navigate(['/easyb'], {});
            //});
        }
    }

    onClickedSave() {
    }

    onHiding($event) {

    }
}