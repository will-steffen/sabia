import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { ServiceHandler } from 'src/handlers/service.handler';
import { NgBlockUI, BlockUI } from 'ng-block-ui';


@Component({
  selector: 'app-camera',
  templateUrl: './camera.page.html',
  styleUrls: ['./camera.page.less']
})
export class CameraPage  {

  @BlockUI() blockUI: NgBlockUI;
  
  constructor(
    public service: ServiceHandler
  ) { }





}