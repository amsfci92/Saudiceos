import { Injectable } from '@angular/core';
import { NewsList } from '../pages/news';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class NewsService {
  constructor(private http: HttpClient) {}

  getAllNews(): Observable<NewsList> {
    return this.http.get<NewsList>(`${env.BASE_URL}/news`);
  }

  getAllNewsInPage(pageNo: number, pageSize: number): Observable<any> {
    return this.http.get<any>(
      `${env.BASE_URL}/news?pageNo=${pageNo}&pageSize=${pageSize}`
    );
  }

  getNewsById(id: unknown): Observable<NewsList> {
    return this.http.get<NewsList>(`${env.BASE_URL}/news/details/${id}`);
  }
}
