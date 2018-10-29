

export class UserSession {
    culture: string;
    isRTL: boolean;
    user: string;
    accessTokenResponse: string;
    errorCode: string;
    errorDescription: string;
    expirationDate: string;
    userId: string;
    
    constructor() {
    }

    public getAccessTokenResponse() {
        let userConfig = sessionStorage.getItem('UserConfig');
        if (userConfig != null && userConfig != "null") {
            let userConfigObj = JSON.parse(userConfig);
            if (userConfigObj.accessTokenResponse != undefined) {
                this.accessTokenResponse = userConfigObj.accessTokenResponse;
            }
        }
        return this.accessTokenResponse;
    }
}