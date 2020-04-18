import { Injectable } from '@angular/core';
import { HttpClient, HttpBackend } from '@angular/common/http';
import { Observable, pipe} from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root',
  })
export class AppConfiguration {
    apiURL: string;
    private http: HttpClient;
    constructor(
        handler: HttpBackend) {
        this.http = new HttpClient(handler);
    }

    public loadConfiguration(): Promise<void> {

        return this.http.get('assets/config/app-config.json').pipe(map
                (response => {
                    // tslint:disable-next-line:no-string-literal
                    this.apiURL = response['apiURL'].toLowerCase();
                })).toPromise();
    }
}
