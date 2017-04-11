import { VehicleService } from './vehicle.service';
import { AddVehicleViewModel } from './addvehicleviewmodel.interface';
import { IFeature } from './feature.interface';
import { IModel } from './model.interface';
import { IMake } from './make.interface';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs/Rx';

@Component({
    selector: 'add-vehicle',
    templateUrl: 'addvehicle.component.html'
})

export class AddvehicleComponent implements OnInit {

    public vehicleViewModel: AddVehicleViewModel;

    public submitted: boolean; //keeping track whether form submitted
    public event: any[] = []; //use latter to display the form changes

    _make;
    _model;
    _feature;

    constructor(private _vehicleService: VehicleService) {
        
    }

    ngOnInit() {
        this._vehicleService.getMakes()
            .subscribe(makes => {
                this._make = makes;
                console.log("MAKES", this._make);
            });


        this._vehicleService.getModelsById(1)
            .subscribe(models => {
                this._model = models;
                console.log("MODELS", this._model);
            });


        this._vehicleService.getFeatures()
            .subscribe(features => {
                this._feature = features;
                console.log("FEATURES", this._feature);
            });
    }

    OnChangeMakeGetModel(id: number) {

    }

    public saveVehicle(isValid: boolean, f: any) {
        console.log(f);
    }
}