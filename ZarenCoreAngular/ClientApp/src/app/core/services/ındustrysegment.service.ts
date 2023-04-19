import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class IndustrySegmentApiService {
    private siteUrl = environment.apiHost + '/IndustrySegment';

    constructor(private http: HttpClient) { }

    deleteIndustrySegment(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addIndustrySegment(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateIndustrySegment(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getIndustrySegmentByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllIndustrySegments(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











