import { ErrorHandler } from '@angular/core';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { UniversalModule } from 'angular2-universal';
import *  as Raven from 'raven-js';

import { AppErrorHandler } from './app.error-handler';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { AddvehicleComponent } from "./components/addvehicle/addvehicle.component";
import { VehicleService } from "./components/addvehicle/vehicle.service";

//Configure Raven for Error logging
Raven
    .config('https://7e5707a5be1146b28bb546c3acd0317e@sentry.io/168098')
    .install();

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        AddvehicleComponent
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        VehicleService
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'add-vehicle', component: AddvehicleComponent },
            { path: 'edit-vehicle/:id', component: AddvehicleComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModule {
}
