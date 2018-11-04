import { Injectable } from '@angular/core';

@Injectable()
export class CameraService {

    hasFace = false;
    showMiniCamera = false;
    onLoop = false;
    showStream = false;
    
    constructor( ) { } 

}