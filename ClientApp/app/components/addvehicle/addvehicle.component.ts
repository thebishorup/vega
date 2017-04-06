import { VehicleService } from './vehicle.service';
import { AddVehicleViewModel } from './addvehicleviewmodel.interface';
import { Feature } from './feature';
import { Model } from './model';
import { Make } from './make';
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

    selectedMake: Make = new Make(0, 'Accura');
    _make: Make[];
    selectedModel: Model;
    _model: Model[];
    _feature: Feature[];

    constructor(private _vehicleService: VehicleService) {
        this._make = this._vehicleService.getMake();
    }

    ngOnInit() {
        //Initialize the ViewModel here [Template Driven]
        this.vehicleViewModel = {
            make: null,
            model: null,
            isregistered: true,
            features: [],
            contactName: '',
            contactPhone: '',
            contactEmail: ''
        }
     }

     OnChangeMakeGetModel(id: number) {
        this._model = this._vehicleService.getModel().filter((item) => item.makeid == id);
        this.selectedModel = new Model(this._model[0].id, this._model[0].name, this._model[0].makeid);
     }

     public saveVehicle(isValid: boolean, f: AddVehicleViewModel) 
     {
         console.log(f);
     }
}