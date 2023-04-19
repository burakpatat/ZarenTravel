import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class PNRApiService {
    private siteUrl = environment.apiHost + '/PNR';

    constructor(private http: HttpClient) { }

    deletePNR(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addPNR(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updatePNR(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getPNRByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllPNRs(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











