import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Subject, Observable } from 'rxjs/Rx';
import { Vehicle } from "./Vehicle";

@Injectable()
export class VehicleService {

    constructor(private _http: Http) {

    }

    getMakes() {
        return this._http.get("/api/makes").map(
            response => response.json()
        ).catch(this.handleError);
    }

    getModelsById(id: number) {
        return this._http.get("/api/models/" + id).map(
            respose => respose.json()
        ).catch(this.handleError);
    }

    getFeatures() {
        return this._http.get("/api/features").map(
            response => response.json()
        ).catch(this.handleError);
    }

    saveVehicle(vehicleModel)
    {
        let bodyString = JSON.stringify(vehicleModel);
        let headers = new Headers({ 'Content-Type': 'application/json' }); 
        let options = new RequestOptions({ headers: headers });

        return this._http.post('/api/vehicles', bodyString, options)
            .map(response => response.json()).catch(this.handleError);
    }

    private handleError(error: Response) {
        return Observable.throw(error.statusText);
    }
}