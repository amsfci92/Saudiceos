import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Settings } from '../pages/Settings';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class SettingService {

  constructor(private http: HttpClient) { }

  getAllSetting(): Observable<Settings> {
    return this.http.get<Settings>(`${env.BASE_URL}/settings`);
  }
}
