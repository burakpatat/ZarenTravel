import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class ExtrasTypeApiService {
    private siteUrl = environment.apiHost + '/ExtrasType';

    constructor(private http: HttpClient) { }

    deleteExtrasType(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addExtrasType(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateExtrasType(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getExtrasTypeByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllExtrasTypes(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











