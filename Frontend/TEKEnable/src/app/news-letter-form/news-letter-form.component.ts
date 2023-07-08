import { Component, OnInit } from '@angular/core';
import {SignUpDetails} from '../models/signUpDetails';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NewsLetterService } from '../services/newsLetter.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-news-letter-form',
  templateUrl: './news-letter-form.component.html',
  styleUrls: ['./news-letter-form.component.scss']

})


export class NewsLetterFormComponent implements OnInit {

  signUpForm: FormGroup;
  isError: boolean;
  errorMessage: string;

  constructor(private formBuilder: FormBuilder,private newsLetterService: NewsLetterService,
    private router: Router) {}

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
    this.isError = false;
    this.errorMessage =  ''; 
    let signUpDetails=new SignUpDetails();
    signUpDetails.email=this.signUpForm.get('email')?.value;
    signUpDetails.sourceOfInformation=this.signUpForm.get('sourceOfInformation')?.value;
    signUpDetails.other=this.signUpForm.get('other')?.value;
    signUpDetails.reason=this.signUpForm.get('reason')?.value;
    console.log(JSON.stringify(signUpDetails));

    this.newsLetterService.SignUp(signUpDetails)
    .subscribe({
      next: response => {
        console.log(response);
        console.log('Sign up successful!');
        this.router.navigate(['/success']);

      },
      error: error => {
        console.log(JSON.stringify(error))
         this.isError = true;
         this.errorMessage =  error.error; ;
      }
    });

  }

}
