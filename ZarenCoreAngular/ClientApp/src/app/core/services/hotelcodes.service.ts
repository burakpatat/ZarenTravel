import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class HotelCodesApiService {
    private siteUrl = environment.apiHost + '/HotelCodes';

    constructor(private http: HttpClient) { }

    deleteHotelCodes(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addHotelCodes(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateHotelCodes(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getHotelCodesByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllHotelCodess(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











