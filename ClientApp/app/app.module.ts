import { BrowserXhr } from '@angular/http';
import { ProgressService, BrowserXhrProgress } from './components/common/progress.service';
import { PhotoService } from './components/view-vehicle/photo.service';
import { ViewVehicleComponent } from './components/view-vehicle/view-vehicle.component';
import { PaginationComponent } from './components/common/pagination.component';
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
import { VehicleListsComponent } from "./components/vehicle-list/vehicle-list.component";

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
        AddvehicleComponent,
        VehicleListsComponent,
        PaginationComponent,
        ViewVehicleComponent
    ],
    providers: [
        { provide: ErrorHandler, useClass: AppErrorHandler },
        { provide: BrowserXhr, useClass: BrowserXhrProgress },
        VehicleService,
        PhotoService,
        ProgressService
    ],
    imports: [
        UniversalModule, // Must be first import. This automatically imports BrowserModule, HttpModule, and JsonpModule too.
        ReactiveFormsModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'vehicle-lists', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'add-vehicle', component: AddvehicleComponent },
            { path: 'edit-vehicle/:id', component: AddvehicleComponent },
            { path: 'vehicle-lists', component: VehicleListsComponent },
            { path: 'vehicle-view/:id', component: ViewVehicleComponent },
            { path: '**', redirectTo: 'vehicle-lists' }
        ])
    ]
})
export class AppModule {
}
