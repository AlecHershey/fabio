import { Injectable } from '@angular/core';
import {
    CanActivate, Router,
    ActivatedRouteSnapshot,
    RouterStateSnapshot
} from '@angular/router';
import { Http } from "@angular/http";
import { map } from 'rxjs/operators';
import { Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from "rxjs";
@Injectable()
export class AuthGuard implements CanActivate {
    constructor(private router: Router, private http: Http) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
        return this.http.get('/api/Login')
            .pipe(
            map((response: Response) => {
                var user = response.json();

                if (user) {
                    if (user.id) {
                        console.log('WERE LOGGED IN BABBYYYYYYY');
                        return true;
                    }
                }
                this.router.navigate(['/login']);
                return false;
            })
            );
    }
}
