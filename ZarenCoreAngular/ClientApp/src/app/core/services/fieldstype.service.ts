import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class FieldsTypeApiService {
    private siteUrl = environment.apiHost + '/FieldsType';

    constructor(private http: HttpClient) { }

    deleteFieldsType(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addFieldsType(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateFieldsType(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getFieldsTypeByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllFieldsTypes(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











