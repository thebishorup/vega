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

    vehicleForm: FormGroup;

    _make;
    _model;
    _feature;

    constructor(private _vehicleService: VehicleService, private _fb: FormBuilder) {

    }

    ngOnInit() {
        this.createForm();

        this._vehicleService.getMakes()
            .subscribe(makes => {
                this._make = makes;
            });

        this._vehicleService.getFeatures()
            .subscribe(features => {
                this._feature = features;
            });
    }

    onChangeMakeGetModel() {

        var makeId = this.vehicleForm.get("make").value;

        this._vehicleService.getModelsById(makeId)
            .subscribe(models => {
                this._model = models;
            });

    }

    onCheckboxChange(id: number) {
        
        //Get the current value(s) of features
        let currentRegisteredFeatures = this.vehicleForm.get("features").value;

        //Insert value into new array if no value present
        if (currentRegisteredFeatures === null) {

            let array = [];
            array.push(id);

            this.vehicleForm.patchValue({
                features: array
            })
        }
        else
        {
            var existedArray = [];
            //Convert the current feature value into array
            existedArray = currentRegisteredFeatures;

            //Check if value existed
            var index = existedArray.indexOf(id);

            if(index < 0)
            {
                //Insert if doesnot exists
                existedArray.push(id);
            }
            else
            {
                //Remove if already exist
                existedArray.splice(index, 1);
            }
            
            //updat feature to the vahicleForm
            this.vehicleForm.patchValue({
                features: existedArray
            })
        }
    }

    createForm() {
        this.vehicleForm = this._fb.group({
            make: ['', Validators.required],
            model: ['', Validators.required],
            isRegistered: ['', Validators.required],
            features: [],
            contactName: ['', Validators.required],
            contactPhone: ['', Validators.required],
            contactEmail: ['', Validators.required]
        });
    }

    public saveVehicle() {
        console.log(this.vehicleForm.value);
    }
}