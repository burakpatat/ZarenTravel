import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class ReservationInformationApiService {
    private siteUrl = environment.apiHost + '/ReservationInformation';

    constructor(private http: HttpClient) { }

    deleteReservationInformation(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addReservationInformation(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateReservationInformation(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getReservationInformationByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllReservationInformations(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











