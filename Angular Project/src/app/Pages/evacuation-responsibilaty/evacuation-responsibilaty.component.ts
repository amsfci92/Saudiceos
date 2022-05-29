import { Component, OnInit } from '@angular/core';
import { SettingService } from 'src/app/core/services/setting.service';

@Component({
  selector: 'app-evacuation-responsibilaty',
  templateUrl: './evacuation-responsibilaty.component.html',
  styleUrls: ['./evacuation-responsibilaty.component.scss'],
})
export class EvacuationResponsibilatyComponent implements OnInit {
  settingDisclaimer: any;

  constructor(private setting: SettingService) {}

  ngOnInit(): void {
    this.getSettingDisclaimer();
  }

  getSettingDisclaimer() {
    this.setting.getAllSetting().subscribe(
      (res: any) => {
        this.settingDisclaimer = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
