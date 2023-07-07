import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-news-letter-form',
  templateUrl: './news-letter-form.component.html',
  styleUrls: ['./news-letter-form.component.scss']
})
export class NewsLetterFormComponent implements OnInit {

  selectedOption='';

  constructor() { }

  ngOnInit(): void {
  }

  onSelectionChange(): void {
    console.log(this.selectedOption);
    if (this.selectedOption !== 'other') {
      // Reset the value of the 'other' field if the selection changes
      //this.resetOtherField();
    }
  }

  resetOtherField(): void {
    this.selectedOption = '';
  }

}
