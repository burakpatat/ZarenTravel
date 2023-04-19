import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class SegmentInformationApiService {
    private siteUrl = environment.apiHost + '/SegmentInformation';

    constructor(private http: HttpClient) { }

    deleteSegmentInformation(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addSegmentInformation(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateSegmentInformation(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getSegmentInformationByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllSegmentInformations(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











