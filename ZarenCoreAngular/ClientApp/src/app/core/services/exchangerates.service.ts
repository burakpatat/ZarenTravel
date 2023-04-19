import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class ExchangeRatesApiService {
    private siteUrl = environment.apiHost + '/ExchangeRates';

    constructor(private http: HttpClient) { }

    deleteExchangeRates(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addExchangeRates(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateExchangeRates(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getExchangeRatesByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllExchangeRatess(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











