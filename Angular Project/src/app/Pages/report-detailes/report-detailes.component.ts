import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ReportService } from 'src/app/core/services/report.service';

@Component({
  selector: 'app-report-detailes',
  templateUrl: './report-detailes.component.html',
  styleUrls: ['./report-detailes.component.scss'],
})
export class ReportDetailesComponent implements OnInit {
  classes: string = 'bg-f4f6fc';
  reporItem: any;
  id!: any;

  constructor(
    private reporListItem: ReportService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((id) => {
      this.id = id.get('id');
      this.getCeoItem();
    });
  }
  getCeoItem() {
    this.reporListItem.getReportById(this.id).subscribe(
      (res: any) => {
        this.reporItem = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
