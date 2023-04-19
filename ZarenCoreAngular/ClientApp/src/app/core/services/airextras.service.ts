import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AirExtrasApiService {
    private siteUrl = environment.apiHost + '/AirExtras';

    constructor(private http: HttpClient) { }

    deleteAirExtras(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAirExtras(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAirExtras(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAirExtrasByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAirExtrass(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











