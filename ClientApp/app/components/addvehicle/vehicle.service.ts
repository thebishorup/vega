import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Subject, Observable } from 'rxjs/Rx';

import  { IMake } from './make.interface';
import { IModel } from './model.interface';
import { IFeature } from './feature.interface';

@Injectable()
export class VehicleService {

    makes: IMake[];
    models: IModel[];
    features: IFeature[];

    constructor(private _http: Http) {

     }

    getMakes(): Observable<IMake[]>
    {
        return this._http.get("/api/makes").map(
            (response) => {
                return <IMake[]>response.json();
            } 
        ).catch(this.handleError);
    }

    getModelsById(id: number): Observable<IModel[]>
    {
        return this._http.get("/api/models/" + id).map(
            (respose) => {
                return <IModel[]>respose.json();
            }
        ).catch(this.handleError);
    }

    getFeatures(): Observable<IFeature[]>
    {
        return this._http.get("/api/features").map(
            (response) => {
                return <IFeature[]>response.json();
            }
        ).catch(this.handleError);
    }

    private handleError(error: Response)
    {
        return Observable.throw(error.statusText);
    }
}