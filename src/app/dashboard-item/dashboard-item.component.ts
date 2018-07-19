import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { map } from "rxjs/operators";
import { Input } from '@angular/core';

export interface IExercise {
    id: number;
    name: string;
}

export interface Workout {
    day?: number;
    id?: number;
    exercises?: WorkoutExercises[];
}

export interface WorkoutExercises {
    workoutid?: number;
    exerciseid?: number;
    exercise?: string;
    sets?: number;
    repetitions?: number;
    id?: number;
}

const httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Component({
  selector: 'dashboard-item',
  templateUrl: './dashboard-item.component.html',
  styleUrls: ['./dashboard-item.component.css']
})
export class DashboardItemComponent implements OnInit {

    constructor(public http: HttpClient) { }

    public exercises: IExercise[] = [];
    public selectedExercise: number = 0;
    public record: Workout = {};
   

    @Input() public day: any = {};

    ngOnInit() {
        this.getExercises();
        
        this.getUserWorkout();
    }

    getExercises() {
        this.http.get('/api/Exercise', httpOptions)
            .pipe(
            map((response: any) => {
                this.exercises = response;
              }
            )
        )
        .subscribe();
    }

    getUserWorkout() {
        this.http.get('/api/Workout?day=' + this.day.id, httpOptions)
            .pipe(
            map((response: any) => {
                this.record = response;
                this.record.day = this.day.id;
            }
            )
            )
            .subscribe();
    }

    addWorkoutExercise() {
        if (!this.record.exercises) {
            this.record.exercises = [];
        }

        if (this.selectedExercise) {
            for (let ex of this.exercises) {
                if (ex.id == this.selectedExercise) {
                    this.record.exercises.push({
                        exerciseid: this.selectedExercise,
                        exercise: ex.name

                    });
                    break;
                  }
               
            }
            
        }
    }

    deleteWorkoutExercise(e: WorkoutExercises) {
        var a = this.record.exercises.indexOf(e);
        this.record.exercises.splice(a, 1);

        if (e.id) {
            this.http.delete('/api/Workout?id='+ e.id, httpOptions)
                .subscribe();
        }
    }
    

    saveChanges() {

        this.record.day = this.day.id;

        this.http.post('/api/Workout', JSON.stringify(this.record), httpOptions)
            .subscribe();
    }

}
