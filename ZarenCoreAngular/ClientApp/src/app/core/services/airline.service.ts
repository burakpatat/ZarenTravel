import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AirlineApiService {
    private siteUrl = environment.apiHost + '/Airline';

    constructor(private http: HttpClient) { }

    deleteAirline(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAirline(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAirline(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAirlineByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAirlines(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











