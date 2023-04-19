import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AgencyGroupApiService {
    private siteUrl = environment.apiHost + '/AgencyGroup';

    constructor(private http: HttpClient) { }

    deleteAgencyGroup(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAgencyGroup(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAgencyGroup(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAgencyGroupByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAgencyGroups(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











