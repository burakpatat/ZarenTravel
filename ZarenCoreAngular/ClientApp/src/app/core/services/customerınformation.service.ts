import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CustomerInformationApiService {
    private siteUrl = environment.apiHost + '/CustomerInformation';

    constructor(private http: HttpClient) { }

    deleteCustomerInformation(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCustomerInformation(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCustomerInformation(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCustomerInformationByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCustomerInformations(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











