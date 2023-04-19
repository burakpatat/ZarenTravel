import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class ChainApiService {
    private siteUrl = environment.apiHost + '/Chain';

    constructor(private http: HttpClient) { }

    deleteChain(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addChain(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateChain(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getChainByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllChains(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











