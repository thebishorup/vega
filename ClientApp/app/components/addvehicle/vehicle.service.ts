import { Injectable } from '@angular/core';
import  { Make } from './make';
import { Model } from './model';
import { Feature } from './feature';

@Injectable()
export class VehicleService {

    constructor() { }

    getMake() 
    {
        return [
            new Make(1, 'Accura'),
            new Make(2, 'BMW'),
            new Make(3, 'Chrysler')
        ];
    }

    getModel() 
    {
        return [
            new Model(1, 'TL', 1),
            new Model(2, 'E4', 2),
            new Model(5, 'Speedy', 3)
        ];
    }

    getFeature()
    {
        return [
            new Feature(1, 'Smooth'),
            new Feature(2, 'Speedy')
        ];
    }
}