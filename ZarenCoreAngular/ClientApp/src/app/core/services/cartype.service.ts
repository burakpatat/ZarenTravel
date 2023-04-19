import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class CarTypeApiService {
    private siteUrl = environment.apiHost + '/CarType';

    constructor(private http: HttpClient) { }

    deleteCarType(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addCarType(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateCarType(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getCarTypeByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllCarTypes(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











