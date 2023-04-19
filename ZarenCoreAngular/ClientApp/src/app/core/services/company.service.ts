import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CompanyApiService {
    private siteUrl = environment.apiHost + '/Company';

    constructor(private http: HttpClient) { }

    deleteCompany(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCompany(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCompany(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCompanyByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCompanys(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











