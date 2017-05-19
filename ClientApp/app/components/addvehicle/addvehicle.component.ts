import { IVehicle } from './model/IVehicle';
import { VehicleService } from './vehicle.service';
import { AddVehicleViewModel } from './addvehicleviewmodel.interface';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs/Rx';
import { ActivatedRoute, Router } from "@angular/router";
import { ISaveVehicle } from "./model/ISaveVehicle";

@Component({
    selector: 'add-vehicle',
    templateUrl: 'addvehicle.component.html'
})

export class AddvehicleComponent implements OnInit {

    vehicleForm: FormGroup;

    _make;
    _model;
    _feature;
    _vehicleId: number;
    _vehicle: IVehicle = {
        id: 0,
        make: { id: 0, name: '' },
        model: { id: 0, name: '' },
        isRegistered: false,
        features: [],
        contact: {
            name: '',
            email: '',
            phone: ''
        },
        lastUpdate: ''
    };

    featuresArray = [];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private _vehicleService: VehicleService,
        private _fb: FormBuilder) {
        route.params.subscribe(p => {
            this._vehicle.id = +p['id'];
        }, error => {
            if (error.status == 404)
                this.router.navigate(['/home']);
        });
    }

    ngOnInit() {
        this.createForm();

        //Conditional get the data from services
        var sources = [
            this._vehicleService.getMakes(),
            this._vehicleService.getFeatures(),
        ];

        if (this._vehicle.id)
            sources.push(this._vehicleService.getVehicle(this._vehicle.id))

        //Implement parallel requests
        Observable.forkJoin(sources).subscribe(data => {
            this._make = data[0];
            this._feature = data[1];

            if (this._vehicle.id)
                this._vehicle = data[2];
            this.populateEditForm();
            console.log(this._vehicle);
        }, err => {
            if (err.status == 404)
                this.router.navigate(['/home']);
        });

        //if(this._vehicle.id)
        // this.populateEditForm();
    }

    private setVehicle(v) {
        //populate the ids: TODO
    }

    onChangeMakeGetModel() {

        this.populateModels();

        //Empty the ModelId
        this.vehicleForm.patchValue({
            modelId: ''
        });
    }

    private populateModels() {
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
        else {
            var existedArray = [];
            //Convert the current feature value into array
            existedArray = currentRegisteredFeatures;

            //Check if value existed
            var index = existedArray.indexOf(id);

            if (index < 0) {
                //Insert if doesnot exists
                existedArray.push(id);
            }
            else {
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
            modelId: ['', Validators.required],
            isRegistered: ['', Validators.required],
            features: [[], Validators.required],
            contact: this._fb.group({
                name: ['', Validators.required],
                phone: ['', [Validators.required, Validators.pattern('[0-9]+')]],
                email: ['', [Validators.required, Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+")]]
            })
        });
    }

    populateEditForm() {
        this.vehicleForm.patchValue({
            make: this._vehicle.make.id,
            modelId: this._vehicle.model.id,
            isRegistered: this._vehicle.isRegistered,
            features: this.populateFeatures(this._vehicle.features),
            contact: this._vehicle.contact
        });
        this.populateModels();
        this.featuresArray = this.vehicleForm.get("features").value;
    }

    populateFeatures(features) {
        var featuresArray = [];
        features.forEach(f => {
            featuresArray.push(f.id);
        });

        return featuresArray;
    }

    public saveVehicle() {
        if (this._vehicle.id) {
            //Update Vehicle
            this._vehicleService.updateVehicle(this.vehicleForm.value, this._vehicle.id)
                .subscribe(x => console.log(x));
        }
        else {
            // console.log(this.vehicleForm.value);
            this._vehicleService.saveVehicle(this.vehicleForm.value)
                .subscribe(response => console.log(response));
        }
    }

    public deleteVehicle() {
        if(confirm("Are you sure?")) {
            this._vehicleService.deleteVehicle(this._vehicle.id)
                .subscribe(x => {
                    this.router.navigate(['/home']);
                });
        }
    }
}