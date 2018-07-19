import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map } from "rxjs/operators";
import { Router } from '@angular/router';

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};
export interface User {
    username?: string;
    password?: string;
}

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    constructor(private http: HttpClient, private formBuilder: FormBuilder, private router: Router) { }
    public user: User = {};
    public form: FormGroup;
    public error: string;

    ngOnInit() {
        this.form = this.formBuilder.group({
            username: ['', [Validators.required, Validators.minLength(6)]],
            password: ['', [Validators.required, Validators.minLength(6)]],
        });
    }

    login() {
        this.error = '';

        this.http.post('/api/Login', JSON.stringify(this.user), httpOptions)
            .pipe(
            map((response: any) => {
                var success = response.success;
                if (success) {
                    this.router.navigate(['/dashboard'])
                }
                else {
                    this.error = 'User not found :(';
                }
            })
            ).subscribe();
    }
}
