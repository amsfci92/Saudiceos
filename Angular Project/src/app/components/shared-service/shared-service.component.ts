import { ServiceCategoryList, ServiceList } from './../../core/pages/service';
import { Component, OnInit } from '@angular/core';
import { ServiceService } from 'src/app/core/services/service.service';

import { environment as env } from 'src/environments/environment';

@Component({
  selector: 'app-shared-service',
  templateUrl: './shared-service.component.html',
  styleUrls: ['./shared-service.component.scss'],
})
export class SharedServiceComponent implements OnInit {
  showInLargScreen!: boolean;
  showInSmallScreen!: boolean;
  serviceListItems: ServiceCategoryList[] = [];
  SITE_BASE_URL: string = '';
  constructor(private serviceList: ServiceService) {}

  ngOnInit(): void {
    this.SITE_BASE_URL = env.BASE_URL;
    this.changeViewInScreenSize();
    this.getServiceList();
  }

  changeViewInScreenSize() {
    if (window.innerWidth >= 991) {
      this.showInLargScreen = true;
      this.showInSmallScreen = false;
    } else {
      this.showInLargScreen = false;
      this.showInSmallScreen = true;
    }
  }

  getServiceList() {
    this.serviceList.getAllService().subscribe((res: any) => {
      this.serviceListItems = res.data;
    });
  }
}
