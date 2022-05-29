import { Component, OnInit } from '@angular/core';
import { NewsList } from 'src/app/core/pages/news';
import { NewsService } from 'src/app/core/services/news.service';
import { environment as env } from 'src/environments/environment';

@Component({
  selector: 'app-news',
  templateUrl: './news.component.html',
  styleUrls: ['./news.component.scss'],
})
export class NewsComponent implements OnInit {
  newsListItems: NewsList[] = [];
  pageNumber: number = 1;
  itemPerPage: number = env.itemPerPage;
  totalItemCount: number = 1;

  constructor(private newsList: NewsService) {}

  ngOnInit(): void {
    this.getAllNewsList();
  }

  // Get All News List
  getAllNewsList() {
    this.newsList.getAllNewsInPage(this.pageNumber, env.itemPerPage).subscribe(
      (res: any) => {
        this.newsListItems = res.data;
        this.totalItemCount = res.totalItemCount;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  changePage(pageNumber: number) {
    this.pageNumber = pageNumber;
    window.scrollTo(0, 0);
    this.getAllNewsList();
  }
}
