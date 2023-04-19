import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AgencyApiService {
    private siteUrl = environment.apiHost + '/Agency';

    constructor(private http: HttpClient) { }

    deleteAgency(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAgency(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAgency(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAgencyByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAgencys(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











