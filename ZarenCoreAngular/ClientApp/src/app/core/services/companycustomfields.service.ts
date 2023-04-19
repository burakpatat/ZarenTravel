import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CompanyCustomFieldsApiService {
    private siteUrl = environment.apiHost + '/CompanyCustomFields';

    constructor(private http: HttpClient) { }

    deleteCompanyCustomFields(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCompanyCustomFields(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCompanyCustomFields(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCompanyCustomFieldsByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCompanyCustomFieldss(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











