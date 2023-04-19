import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';


@Injectable()
export class HotelApiService {
    private siteUrl = environment.apiHost + '/Hotel';

    constructor(private http: HttpClient) { }

    deleteHotel(id: string): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addHotel(data: any): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateHotel(data: any): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getHotelByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllHotels(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











