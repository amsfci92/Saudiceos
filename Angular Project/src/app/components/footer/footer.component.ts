import { Component, OnInit } from '@angular/core';
import { SettingService } from 'src/app/core/services/setting.service';
import { environment as env } from 'src/environments/environment';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  settingFooter: any;
  SITE_BASE_URL: string = '';

  constructor(private setting: SettingService) { }

  ngOnInit(): void {
    this.SITE_BASE_URL = env.BASE_URL;
    this.getSettingFooter()
  }

  getSettingFooter() {
    this.setting.getAllSetting().subscribe((res: any) => {
      this.settingFooter = res
    }, err => {
      console.log(err)
    })
  }

  goToTop() {
    window.scrollTo(0, 0);
  }
}
