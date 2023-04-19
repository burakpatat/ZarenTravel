import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class TerminalApiService {
    private siteUrl = environment.apiHost + '/Terminal';

    constructor(private http: HttpClient) { }

    deleteTerminal(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addTerminal(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateTerminal(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getTerminalByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllTerminals(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











