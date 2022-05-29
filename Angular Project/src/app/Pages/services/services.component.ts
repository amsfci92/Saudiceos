import { Component, OnInit } from '@angular/core';
import { ServiceCategoryList } from 'src/app/core/pages/service';
import { ServiceService } from 'src/app/core/services/service.service';
import { environment as env } from 'src/environments/environment';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss'],
})
export class ServicesComponent implements OnInit {
  serviceListItems: ServiceCategoryList[] = [];
  pageNumber: number = 1;
  itemPerPage: number = env.itemPerPage;
  totalItemCount: number = 1;

  constructor(private serviceList: ServiceService) {}

  ngOnInit(): void {
    this.getAllServiceList();
  }

  getAllServiceList() {
    this.serviceList
      .getAllServiceInPage(this.pageNumber, env.itemPerPage)
      .subscribe(
        (res: any) => {
          this.serviceListItems = res.data;
          this.totalItemCount = res.totalItemCount;
        },
        (err) => {
          console.log(err);
        }
      );
  }

  changePage(pageNumber: number) {
    this.pageNumber = pageNumber;
    this.getAllServiceList();
  }
}
