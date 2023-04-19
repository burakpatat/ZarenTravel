import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AirApiService {
    private siteUrl = environment.apiHost + '/Air';

    constructor(private http: HttpClient) { }

    deleteAir(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAir(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAir(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAirByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAirs(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











