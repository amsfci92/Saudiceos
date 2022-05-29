import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NewsService } from 'src/app/core/services/news.service';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-news-details',
  templateUrl: './news-details.component.html',
  styleUrls: ['./news-details.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class NewsDetailsComponent implements OnInit {
  sectionTitle = 'الأخبار ذات العلاقة';
  classes: string = 'bg-f4f6fc';
  newsItem: any;
  id!: unknown | undefined;
  innerHTMLDisc: any;

  constructor(
    private newsListItem: NewsService,
    private route: ActivatedRoute,
    // private _renderer: Renderer,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (id) => {
        this.id = id.get('id');
        this.getNewsItem();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  // Get News By ID
  getNewsItem() {
    this.newsListItem.getNewsById(this.id).subscribe(
      (res) => {
        this.newsItem = res;
        this.innerHTMLDisc = this.sanitizer.bypassSecurityTrustHtml(
          this.newsItem.description
        );

        console.log(this.newsItem);
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
