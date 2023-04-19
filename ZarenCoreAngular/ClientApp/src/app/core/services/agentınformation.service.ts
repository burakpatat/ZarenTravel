import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class AgentInformationApiService {
    private siteUrl = environment.apiHost + '/AgentInformation';

    constructor(private http: HttpClient) { }

    deleteAgentInformation(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addAgentInformation(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateAgentInformation(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getAgentInformationByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllAgentInformations(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











