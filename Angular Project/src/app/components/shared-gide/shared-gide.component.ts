import { Component, OnInit } from '@angular/core';
import { CeoList } from 'src/app/core/pages/guide';
import { GuideService } from 'src/app/core/services/guide.service';

import { environment as env } from 'src/environments/environment';

@Component({
  selector: 'app-shared-gide',
  templateUrl: './shared-gide.component.html',
  styleUrls: ['./shared-gide.component.scss']
})
export class SharedGideComponent implements OnInit {

  ceoList: CeoList[] = [];
  SITE_BASE_URL: string = '';
  constructor(private guideList: GuideService) { }

  ngOnInit(): void {
    this.SITE_BASE_URL = env.BASE_URL;
    this.getAllCeo()

  }

  // Get All News List
  getAllCeo() {
    this.guideList.getAllCeo().subscribe((res: any) => {
      this.ceoList = res.data
    },
    err => {
      console.log(err);
    });
  }

}
