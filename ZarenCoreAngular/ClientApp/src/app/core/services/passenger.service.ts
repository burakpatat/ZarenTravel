import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class PassengerApiService {
    private siteUrl = environment.apiHost + '/Passenger';

    constructor(private http: HttpClient) { }

    deletePassenger(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addPassenger(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updatePassenger(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getPassengerByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllPassengers(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











