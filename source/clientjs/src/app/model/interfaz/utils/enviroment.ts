import { Language } from "../../organization/language";
import { Dictionary } from "./dictionary";

export class EnviromentData {
    resources: Dictionary<string, string>;
    accessTokenResponse: string;
    internalToken: string;
    refreshToken: string;
    language: Language;

    constructor() {
        this.resources = new Dictionary<string, string>();
        this.language = new Language();
        this.language.countryCode.value = 'es';
        this.language.rightToLeft.value = false;
    }
}