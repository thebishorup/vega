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
    query: any = {};
    columns = [
        { title: 'Id' },
        { title: 'Make', key: 'make', isSortable: true },
        { title: 'Model', key: 'model', isSortable: true },
        { title: 'Contact Name', key: 'contactName', isSortable: true },
        {  }
    ];

    constructor(private _vehicleService: VehicleService) { }

    ngOnInit() {
        this.populateVehicles();

        this._vehicleService.getMakes()
            .subscribe(makes => this._make = makes);
    }

    private populateVehicles() {
        this._vehicleService.getVehicles(this.query)
            .subscribe(vehicles => this._vehicles = vehicles);
    }

    onFilterChange() {
        this.populateVehicles();
    }

    resetFilter() {
        this.query = {};
        this.onFilterChange();
    }

    sortBy(columnName) {
        if(this.query.sortBy === columnName){
            this.query.isSortAscending = !this.query.isSortAscending;
        }else{
            this.query.sortBy = columnName;
            this.query.isSortAscending = true;
        }
        this.populateVehicles();
    }
}