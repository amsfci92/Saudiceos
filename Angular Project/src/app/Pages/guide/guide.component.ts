import { CeoList } from 'src/app/core/pages/guide';
import { SendFileService } from './../../core/services/send-file.service';
import { SendImageService } from './../../core/services/send-image.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GuideService } from 'src/app/core/services/guide.service';
import { environment as env } from 'src/environments/environment';
import { ToastrService } from 'ngx-toastr';
import * as ClassicEditor from '@ckeditor/ckeditor5-build-classic';
declare let $: any;

@Component({
  selector: 'app-guide',
  templateUrl: './guide.component.html',
  styleUrls: ['./guide.component.scss'],
})
export class GuideComponent implements OnInit {
  Editor: any = ClassicEditor;
  ceoList: CeoList[] = [];
  pageNumber: number = 1;
  itemPerPage: number = 6;
  totalItemCount: number = 8;
  searchText: string = '';
  addCeo!: FormGroup;
  imgPathUrl: string = '';
  nationalIDimgPathUrl: any;
  fileName: any;
  imgName: any;
  nationalIDImgName: any;
  responseFileName: string = '';
  responseImageName: string = '';
  responseNationalIDImageName: string = '';

  constructor(
    private ceoListItem: GuideService,
    private fb: FormBuilder,
    private sendImage: SendImageService,
    private sendFile: SendFileService,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getAllCeo();
    this.addCeoForm();
  }

  // Get All News List
  getAllCeo() {
    this.ceoListItem
      .getAllCeoInPage(this.pageNumber, this.itemPerPage, this.searchText)
      .subscribe(
        (res: any) => {
          this.ceoList = res.data;
          this.totalItemCount = res.totalItemCount;
        },
        (err) => {
          console.log(err);
        }
      );
  }

  changePage(pageNumber: number) {
    this.pageNumber = pageNumber;
    window.scrollTo(0, 0)
    this.getAllCeo();
  }

  addCeoForm() {
    this.addCeo = this.fb.group({
      imageUrl: [''],
      nationalIDImageUrl: [''],
      name: [''],
      position: [''],
      email: ['', [Validators.email]],
      cvDescription: [''],
      cvUrl: [''],
    });
  }

  //#region Get Inputs
  get imageUrlIn() {
    return this.addCeo?.get('imageUrl');
  }
  get nationalIDUrlIn() {
    return this.addCeo?.get('nationalIDImageUrl');
  }
  get nameIn() {
    return this.addCeo?.get('name');
  }
  get positionIn() {
    return this.addCeo?.get('position');
  }
  get emailIn() {
    return this.addCeo?.get('email');
  }
  get cvDescriptionIn() {
    return this.addCeo?.get('cvDescription');
  }
  get cvUrlIn() {
    return this.addCeo?.get('cvUrl');
  }
  //#endregion

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
      console.log(form.value);
      this.ceoListItem
        .addNewCeo({
          imageUrl: this.responseImageName,
          nationalIDImageUrl: this.responseNationalIDImageName,
          name: this.nameIn?.value,
          position: this.positionIn?.value,
          email: this.emailIn?.value,
          cvDescription: this.cvDescriptionIn?.value,
          cvUrl: this.responseFileName,
        })
        .subscribe(
          () => {},
          (err) => {
            console.log(err);
          },
          () => {
            $('.preloader-area').fadeOut('slow');
            $('#addCeo').modal('hide');
            this.showSuccess();
          }
        );
    }
  }

  showSuccess() {
    this.toastr.success('', 'تم استلام طلب الإضافة بنجاح.', {
      positionClass: 'toast-bottom-right',
    });
  }

  addCeoSubmit(form: FormGroup) {
    $('.preloader-area').fadeIn();
    this.formData(form);
  }
}
