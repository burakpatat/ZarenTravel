import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AccommodationExtrasApiService {
    private siteUrl = environment.apiHost + '/AccommodationExtras';

    constructor(private http: HttpClient) { }

    deleteAccommodationExtras(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAccommodationExtras(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAccommodationExtras(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAccommodationExtrasByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAccommodationExtrass(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











