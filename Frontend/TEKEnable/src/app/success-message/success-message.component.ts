import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-success-message',
  templateUrl: './success-message.component.html',
  styleUrls: ['./success-message.component.scss']
})
export class SuccessMessageComponent implements OnInit {

  message: string;
  constructor( private router: Router) { 
    this.message="Your registration was successful!";
  }

  ngOnInit(): void {
  }

  goBack():void{
    this.router.navigate(['/']);
  }
}
