import { VehicleService } from './../addvehicle/vehicle.service';
import { IVehicle } from './../addvehicle/model/IVehicle';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'vehicle-lists',
    templateUrl: 'vehicle-lists.component.html'
})

export class VehicleListsComponent implements OnInit {

    _vehicles: IVehicle[];
    _make;
    filter: any = {};

    constructor(private _vehicleService: VehicleService) { }

    ngOnInit() {
        this.populateVehicles();

        this._vehicleService.getMakes()
            .subscribe(makes => this._make = makes);
    }

    private populateVehicles() {
        this._vehicleService.getVehicles(this.filter)
            .subscribe(vehicles => this._vehicles = vehicles);
    }

    onFilterChange() {
        this.populateVehicles();
    }

    resetFilter() {
        this.filter = {};
        this.onFilterChange();
    }
}