import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CurrencyApiService {
    private siteUrl = environment.apiHost + '/Currency';

    constructor(private http: HttpClient) { }

    deleteCurrency(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCurrency(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCurrency(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCurrencyByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCurrencys(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











