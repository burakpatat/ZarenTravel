import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AirportApiService {
    private siteUrl = environment.apiHost + '/Airport';

    constructor(private http: HttpClient) { }

    deleteAirport(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAirport(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAirport(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAirportByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAirports(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











