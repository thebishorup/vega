import { Http } from '@angular/http';
import { Injectable } from '@angular/core';

@Injectable()
export class PhotoService {

    constructor(private _http: Http) { }

    upload(vehicleId, file) {
        var formData = new FormData();
        formData.append('file', file);
        return this._http.post('/api/vehicles/' + vehicleId + '/photos', formData)
            .map(response => response.json());
    }

    getPhotos(vehicleId) {
        return this._http.get('/api/vehicles/' + vehicleId + '/photos')
            .map(response => response.json());
    }
}