import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CountryApiService {
    private siteUrl = environment.apiHost + '/Country';

    constructor(private http: HttpClient) { }

    deleteCountry(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCountry(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCountry(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCountryByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCountrys(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











