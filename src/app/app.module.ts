import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { AppRoutingModule } from './/app-routing.module';
import { RegisterComponent } from './register/register.component';
import { TermsComponent } from './terms/terms.component';
import { LoginComponent } from './login/login.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { OnInit } from '@angular/core';
import { AuthGuard } from './auth-guard.service';
import { DashboardItemComponent } from './dashboard-item/dashboard-item.component';

@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        RegisterComponent,
        TermsComponent,
        LoginComponent,
        DashboardComponent,
        DashboardItemComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        HttpClientModule,
        AppRoutingModule,
        ReactiveFormsModule
    ],
    providers: [
        AuthGuard
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
