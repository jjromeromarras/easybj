export class QueryException {
    exceptionMessage: string;
    isUnauthorizedAccessException: boolean;

    constructor(message, unauthorizedexception) {
        this.exceptionMessage = message;
        this.isUnauthorizedAccessException = unauthorizedexception;
    }
}
