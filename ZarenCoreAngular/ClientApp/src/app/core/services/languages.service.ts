import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from 'environments/environment';

@Injectable()
export class LanguagesApiService {
    private siteUrl = environment.apiHost + '/Languages';

    constructor(private http: HttpClient) { }

    deleteLanguages(id): Observable<any> {
        return this.http.delete<any>(this.siteUrl + "/" + id);
    }

    addLanguages(data): Observable<any> {
        return this.http.post<any>(this.siteUrl, data);
    }

    updateLanguages(data): Observable<any> {
        return this.http.put<any>(this.siteUrl, data);
    }

    getLanguagesByID(id: string): Observable<any> {
        return this.http.get(this.siteUrl + '/' + id);
    }

    getAllLanguagess(): Observable<any> {
        return this.http.get(this.siteUrl);
    }
}











