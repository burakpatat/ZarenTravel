import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AccommodationApiService {
    private siteUrl = environment.apiHost + '/Accommodation';

    constructor(private http: HttpClient) { }

    deleteAccommodation(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAccommodation(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAccommodation(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAccommodationByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAccommodations(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











