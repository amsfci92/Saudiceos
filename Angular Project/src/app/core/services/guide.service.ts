import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CeoList, AddNewCeo, UpdateCeo } from '../pages/guide';
import { environment as env } from 'src/environments/environment';


@Injectable({
  providedIn: 'root',
})
export class GuideService {
  constructor(private http: HttpClient) {}

  getAllCeo(): Observable<CeoList> {
    return this.http.get<CeoList>(`${env.BASE_URL}/ceo`);
  }

  getAllCeoInPage(
    pageNo: number,
    pageSize: number,
    searchText: string
  ): Observable<any> {
    return this.http.get<any>(
      `${env.BASE_URL}/ceo?pageNo=${pageNo}&pageSize=${pageSize}&searchText=${encodeURI( searchText)}`
    );
  }

  getCeoById(id: any): Observable<CeoList> {
    return this.http.get<CeoList>(`${env.BASE_URL}/ceo/details/${id}`);
  }

  addNewCeo(body: any): Observable<AddNewCeo> {
    return this.http.post<AddNewCeo>(`${env.BASE_URL}/ceo/addrequest`, body);
  }

  updateNewCeo(body: any): Observable<UpdateCeo> {
    return this.http.post<UpdateCeo>(`${env.BASE_URL}/ceo/updaterequest`, body);
  }
}
