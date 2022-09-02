import { CeoList } from 'src/app/core/pages/guide';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { GuideService } from 'src/app/core/services/guide.service';
import { SendFileService } from 'src/app/core/services/send-file.service';
import { SendImageService } from 'src/app/core/services/send-image.service';
import { ToastrService } from 'ngx-toastr';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
import { DomSanitizer } from '@angular/platform-browser';
declare let $: any;

@Component({
  selector: 'app-guide-details',
  templateUrl: './guide-details.component.html',
  styleUrls: ['./guide-details.component.scss'],
  encapsulation: ViewEncapsulation.None,
})
export class GuideDetailsComponent implements OnInit {
  Editor: any = ClassicEditor;
  ceoPosition: string = '';
  ceoItem: CeoList = {
    id: 0,
    image: '',
    cvUrl: '',
    company: '',
    createdDate: '',
    cvDescription: '',
    cvNote: '',
    imageUrl: '',
    nationalIDImageUrl: '',
    linkedIn: '',
    name: '',
    twitter: '',
    position: '',
    email: '',
    ceoNews: [
      {
        id: 0,
        description: '',
        image: '',
        note: '',
        title: '',
        createDate: '',
        tags: null,
      },
    ],
  };
  id!: any;
  updateCeo!: FormGroup;
  imgPathUrl: string = '';
  nationalIDimgPathUrl: any;
  fileName: any;
  imgName: any;
  nationalIDImgName: any;
  responseFileName: string = '';
  responseImageName: string = '';
  responseNationalIDImageName: string = '';
  showInLargScreen: boolean = true;
  showInSmallScreen: boolean = false;
  showNewsSection: boolean = false;

  constructor(
    private ceoListItem: GuideService,
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private sendImage: SendImageService,
    private sendFile: SendFileService,
    private toastr: ToastrService,
    public sanitizer: DomSanitizer
  ) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe((id) => {
      this.id = id.get('id');
    });
    this.getCeoItem();
    this.updateCeoForm();
    this.changeViewInScreenSize();
  }

  changeViewInScreenSize() {
    if (window.innerWidth >= 991) {
      this.showInLargScreen = true;
      this.showInSmallScreen = false;
    } else {
      this.showInLargScreen = false;
      this.showInSmallScreen = true;
    }
  }

  getCeoItem() {
    this.ceoListItem.getCeoById(this.id).subscribe(
      (res: any) => {
        this.ceoItem = res;
        if (this.ceoItem?.company){
          this.ceoPosition = `${this.ceoItem?.position} في ${this.ceoItem?.company}`;
        } else {
          this.ceoPosition = `${this.ceoItem?.position}` ;
        }

        if (this.ceoItem.ceoNews.length > 0) {
          this.showNewsSection = true;
        }
        this.setValueInInputs();
      },
      (err) => {
        console.log(err);
      }
    );
  }

  updateCeoForm() {
    this.updateCeo = this.fb.group({
      imageUrl: [''],
      nationalIDImageUrl: [''],
      name: [''],
      position: [''],
      email: ['', [Validators.email]],
      cvDescription: [''],
      cvUrl: [''],
      ceoId: [''],
    });
  }

  get imageUrlIn() {
    return this.updateCeo.get('imageUrl');
  }
  get nationalIDUrlIn() {
    return this.updateCeo.get('nationalIDImageUrl');
  }
  get nameIn() {
    return this.updateCeo.get('name');
  }
  get positionIn() {
    return this.updateCeo.get('position');
  }
  get emailIn() {
    return this.updateCeo.get('email');
  }
  get cvDescriptionIn() {
    return this.updateCeo.get('cvDescription');
  }
  get cvUrlIn() {
    return this.updateCeo.get('cvUrl');
  }

  setValueInInputs() {
    this.imgPathUrl = `https://saudiceos.com/Content/Data/Ceo/images/${this.ceoItem.imageUrl}`;
    this.nameIn?.setValue(this.ceoItem.name);
    this.positionIn?.setValue(this.ceoItem.position);
    this.emailIn?.setValue(this.ceoItem.email);
    // this.cvDescriptionIn?.setValue(this.ceoItem.cvDescription);
    this.cvUrlIn?.setValue(this.ceoItem.cvUrl);
  }

  onSelectImage(e: any) {
    if (e.target.files) {
      $('.preloader-area').fadeIn();
      this.imgName = e.target.files[0];
      const renderImage = new FileReader();
      renderImage.readAsDataURL(e.target.files[0]);
      renderImage.onload = (event: any) => {
        this.imgPathUrl = event.target.result;
        this.formDataImg();
      };
    }
  }

  onSelectNationalIDImage(e: any) {
    if (e.target.files) {
      $('.preloader-area').fadeIn();
      this.nationalIDImgName = e.target.files[0];
      const renderNationalIDImage = new FileReader();
      renderNationalIDImage.readAsDataURL(e.target.files[0]);
      renderNationalIDImage.onload = (event: any) => {
        this.nationalIDimgPathUrl = event.target.result;
        this.formNationalIDDataImg();
      };
    }
  }

  onSelectFile(e: any) {
    if (e.target.files) {
      $('.preloader-area').fadeIn();
      this.fileName = e.target.files[0];
      const renderFile = new FileReader();
      renderFile.readAsDataURL(e.target.files[0]);
      renderFile.onload = () => {
        this.formDataFile();
      };
    }
  }

  formDataImg() {
    const formDataImg = new FormData();
    formDataImg.append('img', this.imgName);
    this.sendImage.sendImage(formDataImg).subscribe(
      (res) => {
        this.responseImageName = res;
        $('.preloader-area').fadeOut('slow');
      },
      (err) => console.log(err)
    );
  }

  formNationalIDDataImg() {
    const formNationalIDDataImg = new FormData();
    formNationalIDDataImg.append('img', this.nationalIDImgName);
    this.sendImage.sendImage(formNationalIDDataImg).subscribe(
      (res) => {
        this.responseNationalIDImageName = res;
        $('.preloader-area').fadeOut('slow');
      },
      (err) => console.log(err)
    );
  }

  formDataFile() {
    const formDataFile = new FormData();
    formDataFile.append('file', this.fileName);
    this.sendFile.sendFile(formDataFile).subscribe(
      (res) => {
        this.responseFileName = res;
        $('.preloader-area').fadeOut('slow');
      },
      (err) => console.log(err)
    );
  }

  formData(form: FormGroup) {
    if (form.valid) {
      this.ceoListItem
        .updateNewCeo({
          imageUrl: this.responseImageName,
          nationalIDImageUrl: this.responseNationalIDImageName,
          name: this.nameIn?.value,
          position: this.positionIn?.value,
          email: this.emailIn?.value,
          cvDescription: this.cvDescriptionIn?.value,
          cvUrl: this.responseFileName,
          ceoId: this.id,
        })
        .subscribe(
          () => {},
          (err) => {
            console.log(err);
          },
          () => {
            $('.preloader-area').fadeOut('slow');
            $('#updateCeo').modal('hide');
            this.showSuccess();
          }
        );
    }
  }

  showSuccess() {
    this.toastr.success(
      '',
      'تم استلام طلب التحديث بنجاح، وسيتم معالجته في أقرب وقت.',
      {
        positionClass: 'toast-bottom-right',
      }
    );
  }

  updateCeoSubmit(form: FormGroup) {
    $('.preloader-area').fadeIn();
    if (!this.imgName) {
      this.responseImageName = this.ceoItem.imageUrl;
    }
    this.formData(form);
  }
}
