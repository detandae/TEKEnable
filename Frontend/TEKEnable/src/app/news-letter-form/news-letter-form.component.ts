import { Component, OnInit } from '@angular/core';
import {SignUpDetails} from '../models/signUpDetails';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-news-letter-form',
  templateUrl: './news-letter-form.component.html',
  styleUrls: ['./news-letter-form.component.scss']

})


export class NewsLetterFormComponent implements OnInit {

  signUpForm: FormGroup;

  constructor(private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.signUpForm = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      sourceOfInformation: ['', Validators.required],
      other: '',
      reason: ''
    });
  }

  isEmailValid(): boolean {
    const emailControl = this.signUpForm.get('email');
    return emailControl?.valid || !emailControl?.touched;
  }
  onSelectionChange():void{
    console.log( this.signUpForm.get('sourceOfInformation')?.value);
  }

  shouldDisableSubmit(): boolean {
    return !this.signUpForm.valid;
  }

  onSubmitClicked() {
    let signUpDetails=new SignUpDetails();
    signUpDetails.email=this.signUpForm.get('sourceOfInformation')?.value;
    signUpDetails.sourceOfInformation=this.signUpForm.get('sourceOfInformation')?.value;
    signUpDetails.other=this.signUpForm.get('other')?.value;
    signUpDetails.reason=this.signUpForm.get('reason')?.value;
    console.log(JSON.stringify(signUpDetails));
  }

}
