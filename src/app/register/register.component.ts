import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

export interface User {
    username?: string;
    email?: string;
    password?: string;
}

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    constructor(private http: HttpClient, private formBuilder: FormBuilder) { }

    public user: User = {};
    public form: FormGroup;

    ngOnInit() {
        this.form = this.formBuilder.group({
            username: ['', [Validators.required, Validators.minLength(6)]],
            password: ['', [Validators.required, Validators.minLength(6)]],
            email: ['', Validators.required],
            TCA: [Validators.required]
        });
    }

    save() {
        this.http.post('/api/UserAccount', JSON.stringify(this.user), httpOptions)
            .subscribe();
    }
}
