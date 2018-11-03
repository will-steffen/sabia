import { Component, ViewChild, ElementRef, OnInit, Input } from '@angular/core';
import { ServiceHandler } from 'src/handlers/service.handler';
import { NgBlockUI, BlockUI } from 'ng-block-ui';


@Component({
  selector: 'app-face-view',
  templateUrl: './face-view.component.html',
  styleUrls: ['./face-view.component.less']
})
export class FaceViewComponent implements OnInit {
  @ViewChild("video") video: ElementRef;
  @ViewChild("canvas") canvas: ElementRef;
  hasFace = false;
  @BlockUI() blockUI: NgBlockUI;

  @Input() showCanvas = false;
  @Input() showBlock = false;
  @Input() onResult = function(result: boolean){};
  @Input() onRequest = function(){};
  
  constructor(
    public service: ServiceHandler
  ) { }

  ngOnInit() { 
      if(this.showCanvas){
        this.canvas.nativeElement.style.display = 'block';
      }
  }

  ngAfterViewInit() {
    if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
      navigator.mediaDevices.getUserMedia({ video: true }).then(stream => {
        this.video.nativeElement.src = window.URL.createObjectURL(stream);
        this.video.nativeElement.play();
      });
    }
    this.capture();
  }

  capture() {
    // this.canvas.nativeElement.style.display = 'none';
    const context = this.canvas.nativeElement.getContext("2d");
    context.clearRect(0, 0, 640, 480);
    context.drawImage(this.video.nativeElement, 0, 0, 640, 480);
    let url = this.canvas.nativeElement.toDataURL("image/png");
    let blob = this.makeblob(url);
    if(this.showBlock) this.blockUI.start();
    this.onRequest();
    this.service.analyseImage(blob).then(data => {
      // console.log(data);
      // let faceRectangle = {
      //   height: 201,
      //   left: 292,
      //   top: 278,
      //   width: 223
      // };
      if(data.length > 0){
        this.hasFace = true;
        for(let i = 0; i < data.length; i++){
          let f = data[i].faceRectangle;
          context.beginPath();
          context.lineWidth = "2";
          context.strokeStyle = "red";

          context.rect(f.left, f.top, f.width, f.height);
          context.stroke();
        }
      }else{
        this.hasFace = false;
      }  
      this.onResult(this.hasFace);
      // this.canvas.nativeElement.style.display = 'block';
      if(this.showBlock) this.blockUI.stop();
      setTimeout(() => this.capture(), 3000);
    });
    //this.captures.push(this.canvas.nativeElement.toDataURL("image/png"));
  }

  private makeblob(dataURL) {
    const BASE64_MARKER = ';base64,';
    const parts = dataURL.split(BASE64_MARKER);
    const contentType = parts[0].split(':')[1];
    const raw = window.atob(parts[1]);
    const rawLength = raw.length;
    const uInt8Array = new Uint8Array(rawLength);

    for (let i = 0; i < rawLength; ++i) {
      uInt8Array[i] = raw.charCodeAt(i);
    }

    return new Blob([uInt8Array], { type: contentType });
  }

}