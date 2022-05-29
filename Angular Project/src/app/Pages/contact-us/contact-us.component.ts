import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactSend } from 'src/app/core/pages/contactus';
import { ContactUsService } from 'src/app/core/services/contact-us.service';
import { SettingService } from 'src/app/core/services/setting.service';
declare let $: any;

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss'],
})
export class ContactUsComponent implements OnInit {
  showSendDone: boolean = false;
  showContactForm: boolean = true;
  contactUsForm!: FormGroup;
  settingContact: any;

  constructor(
    private fb: FormBuilder,
    private sendData: ContactUsService,
    private setting: SettingService
  ) {}

  ngOnInit(): void {
    this.contactSend();
    this.getSettingContact();
  }

  contactSend() {
    this.contactUsForm = this.fb.group({
      name: [''],
      email: ['', [Validators.email]],
      subject: [''],
      message: [''],
    });
  }

  get nameIn() {
    return this.contactUsForm.get('name');
  }
  get emailIn() {
    return this.contactUsForm.get('email');
  }
  get msgSubjectIn() {
    return this.contactUsForm.get('subject');
  }
  get messageIn() {
    return this.contactUsForm.get('message');
  }

  submited(form: FormGroup) {
    debugger;
    $('.preloader-area').fadeIn(500);
    if (form.valid) {
      this.sendData
        .sendContactForm({
          name: this.nameIn?.value,
          email: this.emailIn?.value,
          subject: this.msgSubjectIn?.value,
          message: this.messageIn?.value,
        })
        .subscribe(
          () => {},
          (err) => {
            console.log(err);
          },
          () => {
            this.showSendDone = true;
            this.showContactForm = false;
            $('.preloader-area').fadeOut(500);
          }
        );
    }
  }

  getSettingContact() {
    this.setting.getAllSetting().subscribe(
      (res: any) => {
        this.settingContact = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
