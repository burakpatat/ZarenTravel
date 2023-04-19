import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class GDSApiService {
    private siteUrl = environment.apiHost + '/GDS';

    constructor(private http: HttpClient) { }

    deleteGDS(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addGDS(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateGDS(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getGDSByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllGDSs(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











