import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class PassengerInformationApiService {
    private siteUrl = environment.apiHost + '/PassengerInformation';

    constructor(private http: HttpClient) { }

    deletePassengerInformation(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addPassengerInformation(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updatePassengerInformation(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getPassengerInformationByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllPassengerInformations(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











