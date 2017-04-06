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

    public submitted: boolean; //keeping track whether form submitted
    public event: any[] = []; //use latter to display the form changes

    private _make: Make[] = [new Make(1, 'Accura')];
    private _model: Model[];
    private _feature: Feature[];

    constructor() {}

    ngOnInit() {
        
     }

     OnChangeMakeGetModel(id: number) {

     }

     getMakes() {
         return [
             new Make(1, 'Accura')
         ]
     }
}