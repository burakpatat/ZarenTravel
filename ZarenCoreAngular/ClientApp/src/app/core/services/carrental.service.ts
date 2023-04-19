import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CarRentalApiService {
    private siteUrl = environment.apiHost + '/CarRental';

    constructor(private http: HttpClient) { }

    deleteCarRental(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCarRental(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCarRental(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCarRentalByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCarRentals(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











