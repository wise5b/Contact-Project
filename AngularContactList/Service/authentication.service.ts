import { Injectable } from '@angular/core';
import { AdalService } from 'ng2-adal/dist/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';

@Injectable()
export class AuthenticationService {
    constructor(private adalService: AdalService ) {}

    public getToken(): Observable<string> {
        return this.adalService.acquireToken(localStorage.getItem('apiKey')).map(
            token => token.toString()
        );
    }
}