import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CompanyDivisionsApiService {
    private siteUrl = environment.apiHost + '/CompanyDivisions';

    constructor(private http: HttpClient) { }

    deleteCompanyDivisions(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCompanyDivisions(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCompanyDivisions(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCompanyDivisionsByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCompanyDivisionss(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











