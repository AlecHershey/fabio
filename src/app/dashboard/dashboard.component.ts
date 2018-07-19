import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map } from "rxjs/operators";

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};
@Component({
    selector: 'app-dashboard',
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent {
    constructor(private http: HttpClient) { }

    public days: {} = [];

    ngOnInit() {
        this.days = [
            {
                name: 'Monday',
                id: 1,
            },
            {
                name: 'Tuesday',
                id: 2,
            },
            {
                name: 'Wednesday',
                id: 3,
            }, {
                name: 'Thursday',
                id: 4,
            }, {
                name: 'Friday',
                id: 5,
            }, {
                name: 'Saturday',
                id: 6,
            },
        ];
    }
}
