import { Validators } from '@angular/forms';
import { ProgressService } from './../common/progress.service';
import { PhotoService } from './photo.service';
import { Component, OnInit, ElementRef, ViewChild, NgZone } from '@angular/core';
import { ActivatedRoute, Router } from "@angular/router";
import { IVehicle } from "../addvehicle/model/IVehicle";
import { VehicleService } from "../addvehicle/vehicle.service";

@Component({
    selector: 'view-vehicle',
    templateUrl: 'view-vehicle.component.html'
})

export class ViewVehicleComponent implements OnInit {

    vehicleId;
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

    @ViewChild('fileInput') fileInput: ElementRef;
    photos: any[];
    progress: any;

    constructor(
        private zone: NgZone,
        private route: ActivatedRoute,
        private router: Router,
        private _vehicleService: VehicleService,
        private _photoService: PhotoService,
        private _progressService: ProgressService
    ) {
        route.params.subscribe(p => {
            this.vehicleId = +p['id'];
            if (isNaN(this.vehicleId) || this.vehicleId <= 0) {
                router.navigate(['/vehicle-lists']);
            }
        }, error => {
            if (error.status == 404)
                this.router.navigate(['/vehicle-lists']);
        });
    }

    ngOnInit() {
        this._vehicleService.getVehicle(this.vehicleId)
            .subscribe(vehicle => this._vehicle = vehicle,
            error => {
                if (error.status == 404) {
                    this.router.navigate(['/vehicle-lists'])
                }
            });

        this._photoService.getPhotos(this.vehicleId)
            .subscribe(photos => this.photos = photos);
    }

    deleteVehicle() {
        if (confirm("Are you sure?")) {
            this._vehicleService.deleteVehicle(this.vehicleId)
                .subscribe(x => {
                    this.router.navigate(['/vehicle-lists']);
                });
        }
    }

    uploadPhoto() {

        this._progressService.startTracking()
            .subscribe(progress => {
                console.log(progress);
                this.zone.run(() => {
                    this.progress = progress;
                });
            },
            null,
            () => { this.progress = null; });

        var nativeElement = this.fileInput.nativeElement;
        var file = nativeElement.files[0];
        nativeElement.value = '';
        this._photoService.upload(this.vehicleId, file)
            .subscribe(photo => {
                this.photos.push(photo);
            },
            error => {
                console.log(error.text());
            });
    }
}