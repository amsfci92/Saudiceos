import { Component, OnInit } from '@angular/core';
import { SettingService } from 'src/app/core/services/setting.service';

@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

    settingNavbar: any;

    constructor(private setting: SettingService) { }
  
    ngOnInit(): void {
        this.getSettingNavbar() ;
    }

    getSettingNavbar() {
        this.setting.getAllSetting().subscribe((res: any) => {
            this.settingNavbar = res
        }, err => {
            console.log(err);  
        })
    }

}
