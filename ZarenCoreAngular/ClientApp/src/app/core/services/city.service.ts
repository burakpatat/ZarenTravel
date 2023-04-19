import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CityApiService {
    private siteUrl = environment.apiHost + '/City';

    constructor(private http: HttpClient) { }

    deleteCity(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCity(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCity(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCityByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCitys(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











