import { Component } from '@angular/core';
import {NgbNavConfig} from '@ng-bootstrap/ng-bootstrap';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [NgbNavConfig]
})



export class AppComponent {
  constructor(config: NgbNavConfig) {
    // customize default values of navs used by this component tree
    config.destroyOnHide = false;
    config.roles = false;
  }
  title = 'BudgetTrackerSPA';
}
