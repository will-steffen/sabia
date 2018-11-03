import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class AlertHandler {

    constructor(
        private toastr: ToastrService
    ) { }

    show(str: string) {
        this.toastr.info(str);
    }

    error(str: string) {
        this.toastr.error(str);
    }

    success(str: string) {
        this.toastr.success(str);
    } 

}