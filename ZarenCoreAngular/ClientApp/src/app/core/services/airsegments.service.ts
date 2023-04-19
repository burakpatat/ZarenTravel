import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AirSegmentsApiService {
    private siteUrl = environment.apiHost + '/AirSegments';

    constructor(private http: HttpClient) { }

    deleteAirSegments(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAirSegments(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAirSegments(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAirSegmentsByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAirSegmentss(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











