import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { StorageHandler } from './storage.handler';
import { Table } from 'src/enums/table';
import { User } from 'src/models/user';

let subId = 'bdc4264b01cc4fcf9132b8bc447a3cc9';

var imageAnalysisUrl = "https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect";

@Injectable()
export class ServiceHandler {
    constructor(
        public http: HttpClient,
        private storage: StorageHandler
    ) { }

    post(path: string, body: any): Promise<any> {
        return this.http.post(path, body).toPromise();
    }

    get(path: string): Promise<any> {
        return this.http.get(path).toPromise();
    }

    analyseImage(blob): Promise<any> {
        const params = new HttpParams()
            .set('returnFaceId', 'false')
            .set('returnFaceLandmarks', 'false')
            .set( 'returnFaceAttributes', '' );
        const headers = this.getHeaders(subId);
        return this.http.post(imageAnalysisUrl, blob, {params, headers}).toPromise();
    }

    private getHeaders(subscriptionKey: string) {
        let headers = new HttpHeaders();
        headers = headers.set('Content-Type', 'application/octet-stream');
        headers = headers.set('Ocp-Apim-Subscription-Key', subscriptionKey);       
    
        return headers;
    }

}