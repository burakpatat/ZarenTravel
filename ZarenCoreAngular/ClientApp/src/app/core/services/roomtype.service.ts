import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class RoomTypeApiService {
    private siteUrl = environment.apiHost + '/RoomType';

    constructor(private http: HttpClient) { }

    deleteRoomType(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addRoomType(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateRoomType(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getRoomTypeByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllRoomTypes(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











