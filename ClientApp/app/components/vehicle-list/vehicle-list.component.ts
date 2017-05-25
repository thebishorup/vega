import { VehicleService } from './../addvehicle/vehicle.service';
import { IVehicle } from './../addvehicle/model/IVehicle';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'vehicle-lists',
    templateUrl: 'vehicle-lists.component.html'
})

export class VehicleListsComponent implements OnInit {

    _vehicles: IVehicle[];

    constructor(private _vehicleService: VehicleService) { }

    ngOnInit() {
        this._vehicleService.getVehicles()
            .subscribe(vehicles => this._vehicles = vehicles);
     }
}