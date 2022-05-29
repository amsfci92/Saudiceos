import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class SendImageService {
  constructor(private http: HttpClient) {}

  sendImage(body: any): Observable<any> {
    return this.http.post<any>(`${env.UPLOADER_API}/img`, body, {
      params: { type: '6' },
    });
  }
}
