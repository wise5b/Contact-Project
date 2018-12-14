import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { AuthenticationService } from './authentication.service';
import { IContact } from '../Model/contact';

@Injectable()
export class ContactService {
    private url = "http://localhost:36096/Contact";
    constructor(private _http: Http,
        private authenticationService: AuthenticationService) { }

    getContacts(): Observable<any> {
        let headers = new Headers();
        return this.authenticationService.getToken()
            .mergeMap(token => {
                headers.append('Authorization', 'Bearer ' +  token);
                let options = new RequestOptions({ headers: headers });
                return this._http.get(this.url + '/Get', options)
                    .map((response: Response) => <any>response.json())
                    .catch(this.handleError);
            });
    }

    addContact(contact: IContact): Observable<Response> {
        let headers = new Headers();
        return this.authenticationService.getToken()
            .mergeMap(token => {
                headers.append('Authorization', 'Bearer ' +  token);
                let options = new RequestOptions({ headers: headers });
                return this._http.post(this.url + '/Add', contact, options)
                    .map((response: Response) => <any>response.json())
                    .catch(this.handleError);
            });
    }

    updateContact(contact: IContact): Observable<Response> {
        let headers = new Headers();
        return this.authenticationService.getToken()
            .mergeMap(token => {
                headers.append('Authorization', 'Bearer ' +  token);
                let options = new RequestOptions({ headers: headers });
                return this._http.put(this.url + '/Update', contact, options)
                    .map((response: Response) => <any>response.json())
                    .catch(this.handleError);
            });
    }

    deleteContact(id: string): Observable<Response> {
        let headers = new Headers();
        return this.authenticationService.getToken()
            .mergeMap(token => {
                headers.append('Authorization', 'Bearer ' +  token);
                let options = new RequestOptions({ headers: headers });
                return this._http.delete(this.url + '/Delete/' + id, options)
                    .map((response: Response) => <any>response.json())
                    .catch(this.handleError);
            });
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

}
