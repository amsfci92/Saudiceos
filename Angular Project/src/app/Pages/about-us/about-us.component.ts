import { Component, OnInit } from '@angular/core';
import { SettingService } from 'src/app/core/services/setting.service';

@Component({
  selector: 'app-about-us',
  templateUrl: './about-us.component.html',
  styleUrls: ['./about-us.component.scss'],
})
export class AboutUsComponent implements OnInit {
  settingAbout: any;

  constructor(private setting: SettingService) {}

  ngOnInit(): void {
    this.getSettingAbout();
  }

  getSettingAbout() {
    this.setting.getAllSetting().subscribe(
      (res: any) => {
        this.settingAbout = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
