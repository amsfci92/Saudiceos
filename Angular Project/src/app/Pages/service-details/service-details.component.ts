import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServiceService } from 'src/app/core/services/service.service';

@Component({
  selector: 'app-service-details',
  templateUrl: './service-details.component.html',
  styleUrls: ['./service-details.component.scss'],
})
export class ServiceDetailsComponent implements OnInit {
  serviceItem: any;
  id!: unknown | undefined;
  imageSlide: any;

  constructor(
    private serviceListItem: ServiceService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (id) => {
        this.id = id.get('id');
        this.getServiceItem();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  getServiceItem() {
    this.serviceListItem.getServiceById(this.id).subscribe(
      (res) => {
        this.serviceItem = res;
        this.imageSlide = this.serviceItem.sliderImages?.split(',');
        console.log(this.serviceItem);
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
