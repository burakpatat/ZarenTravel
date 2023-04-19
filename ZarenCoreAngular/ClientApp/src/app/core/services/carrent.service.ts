import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class carrentApiService {
    private siteUrl = environment.apiHost + '/carrent';

    constructor(private http: HttpClient) { }

    deletecarrent(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addcarrent(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updatecarrent(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getcarrentByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllcarrents(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











