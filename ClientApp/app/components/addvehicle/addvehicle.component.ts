import { VehicleService } from './vehicle.service';
import { AddVehicleViewModel } from './addvehicleviewmodel.interface';
import { IFeature } from './feature.interface';
import { IModel } from './model.interface';
import { IMake } from './make.interface';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
    selector: 'add-vehicle',
    templateUrl: 'addvehicle.component.html'
})

export class AddvehicleComponent implements OnInit {

    public vehicleViewModel: AddVehicleViewModel;

    public submitted: boolean; //keeping track whether form submitted
    public event: any[] = []; //use latter to display the form changes

    _make: IMake[];
    _model: IModel[];
    _feature: IFeature[];

    constructor(private _vehicleService: VehicleService) {
        this._vehicleService.getMakes()
            .subscribe(makes => console.log(makes));

        this._vehicleService.getModelsById(1)
            .subscribe(models => console.log(models));

        this._vehicleService.getFeatures()
            .subscribe(features => console.log(features));
    }

    ngOnInit() {
        
     }

     OnChangeMakeGetModel(id: number) {

     }

     public saveVehicle(isValid: boolean, f: any) 
     {
         console.log(f);
     }
}