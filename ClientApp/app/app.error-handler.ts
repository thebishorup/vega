import * as Raven from 'raven-js';
import { ErrorHandler, isDevMode } from "@angular/core";

export class AppErrorHandler implements ErrorHandler {
    handleError(error: any): void {

        if(!isDevMode())
            //Raven (error logging configurations)
            Raven.captureException(error.originalError || error);
        else
            throw error;

        console.log("Error");
    }
}