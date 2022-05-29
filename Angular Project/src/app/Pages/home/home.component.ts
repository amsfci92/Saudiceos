import { Settings } from './../../core/pages/Settings';
import { SettingService } from './../../core/services/setting.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    sectionTitle = "آخر الأخبار";
    classes: string = 'bg-f4f6fc';
    settingHome: any

    constructor(private setting: SettingService) { }

    ngOnInit(): void {
      this.getSettingHome()
    }

    getSettingHome() {
      this.setting.getAllSetting().subscribe((res: any) => {
          this.settingHome = res
          console.log(res)
      })
  }
    
}

