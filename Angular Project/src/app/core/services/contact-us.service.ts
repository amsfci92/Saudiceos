import { ContactSend } from './../pages/contactus';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ContactUsService {

  constructor(private http: HttpClient) {}

  sendContactForm(body: ContactSend): Observable<ContactSend> {
    return this.http.post<ContactSend>(`${env.BASE_URL}/contactus/add`, body);  
  }
}
