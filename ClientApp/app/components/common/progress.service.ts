import { Subject } from 'rxjs/Subject';
import { Injectable } from '@angular/core';
import { BrowserXhr } from "@angular/http";

@Injectable()
export class ProgressService {

    private uploadProgress: Subject<any> = new Subject();

    startTracking() {
        this.uploadProgress = new Subject();
        return this.uploadProgress;
    }

    notify(progress) {
        this.uploadProgress.next(process);
    }

    endTracking() {
        this.uploadProgress.complete();
    }
}


@Injectable()
export class BrowserXhrProgress extends BrowserXhr {

    constructor(private _progressService: ProgressService) { super(); }

    build(): XMLHttpRequest {
        var xhr: XMLHttpRequest = super.build();

        xhr.upload.onprogress = (event) => {
            this._progressService.notify(this.createProgress(event));
        }

        //Release once completed to avoid memory leaks
        xhr.upload.onloadend = () => {
            this._progressService.endTracking();
        }

        return xhr;
    }

    private createProgress(event) {
        return {
            total: event.total,
            percentage: Math.round(event.loaded / event.total * 100)
        };
    }
}