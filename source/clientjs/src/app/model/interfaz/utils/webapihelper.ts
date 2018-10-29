import { Headers } from '@angular/http';
import { HttpHeaders } from '@angular/common/http';

export class WebAPIHelper {

    // Headers
    public static createGetHeaders(): HttpHeaders {
        let headers = new HttpHeaders ();
        headers.append('Accept', 'q=0.8;application/json;q=0.9');
        return headers;
    }

    public static createPostHeaders(): HttpHeaders {
        let headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded' });
        headers.append('Accept', 'q=0.8;application/json;q=0.9');
        return headers;
    }
}