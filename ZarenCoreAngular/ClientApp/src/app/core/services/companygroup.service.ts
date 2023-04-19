import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CompanyGroupApiService {
    private siteUrl = environment.apiHost + '/CompanyGroup';

    constructor(private http: HttpClient) { }

    deleteCompanyGroup(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCompanyGroup(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCompanyGroup(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCompanyGroupByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCompanyGroups(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











