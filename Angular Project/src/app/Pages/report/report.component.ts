import { Component, OnInit } from '@angular/core';
import { ReportList } from 'src/app/core/pages/Report';
import { ReportService } from 'src/app/core/services/report.service';
import { environment as env } from 'src/environments/environment';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.scss'],
})
export class ReportComponent implements OnInit {
  reportListItems: ReportList[] = [];
  pageNumber: number = 1;
  itemPerPage: number = env.itemPerPage;
  totalItemCount: number = 1;

  constructor(private reportList: ReportService) {}

  ngOnInit(): void {
    this.getReportList();
  }

  getReportList() {
    this.reportList
      .getAllReportInPage(this.pageNumber, env.itemPerPage)
      .subscribe((res: any) => {
        this.reportListItems = res.data;
        this.totalItemCount = res.totalItemCount;
      });
  }

  changePage(pageNumber: number) {
    this.pageNumber = pageNumber;
    this.getReportList();
  }
}
