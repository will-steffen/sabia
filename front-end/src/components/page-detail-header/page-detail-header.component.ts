import { Component, Input } from '@angular/core';


@Component({
    selector: 'app-page-detail-header',
    templateUrl: './page-detail-header.component.html',
    styleUrls: ['./page-detail-header.component.less']
})
export class PageDetailHeaderComponent {
    @Input() title = "";
    @Input() description = "";
    @Input() actionButton = "";
    @Input() onActionButton = () => {};
}