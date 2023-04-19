import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class PCCApiService {
    private siteUrl = environment.apiHost + '/PCC';

    constructor(private http: HttpClient) { }

    deletePCC(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addPCC(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updatePCC(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getPCCByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllPCCs(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











