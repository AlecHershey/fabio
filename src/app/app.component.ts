import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    constructor(private http: Http) { }
    loggedIn: boolean;
    exercises: string[] = [];
    public user: {} = {};
    ngOnInit() {
        this.loggedIn = false;
        this.http.get('/api/Login')
            .pipe(
            map((response: Response) => {
                this.user = response.json();
                if (this.user == null) {
                    this.loggedIn = false;
                }
                else {
                    this.loggedIn = true;
                }
            })
            ).subscribe();
    }

    logout() {
        this.http.put('/api/Login', {})
            .pipe(
            map(
                () => location.reload()

            )
            ).subscribe();
    }
}
