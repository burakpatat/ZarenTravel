import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class BrokerApiService {
    private siteUrl = environment.apiHost + '/Broker';

    constructor(private http: HttpClient) { }

    deleteBroker(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addBroker(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateBroker(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getBrokerByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllBrokers(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











