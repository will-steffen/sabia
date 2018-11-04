import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent {
  title = 'Sabia';
  constructor(){
    console.log('https://40.117.230.30:9001/api/mock/test');
  }
}
