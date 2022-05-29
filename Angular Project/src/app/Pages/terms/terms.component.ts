import { Component, OnInit } from '@angular/core';
import { SettingService } from 'src/app/core/services/setting.service';

@Component({
  selector: 'app-terms',
  templateUrl: './terms.component.html',
  styleUrls: ['./terms.component.scss'],
})
export class TermsComponent implements OnInit {
  settingTermsOfUse: any;

  constructor(private setting: SettingService) {}

  ngOnInit(): void {
    this.getSettingTermsOfUse();
  }

  getSettingTermsOfUse() {
    this.setting.getAllSetting().subscribe(
      (res: any) => {
        this.settingTermsOfUse = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
