import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewsLetterFormComponent } from './news-letter-form/news-letter-form.component';
import { SuccessMessageComponent } from './success-message/success-message.component';

const routes: Routes = [
  { path: '', component: NewsLetterFormComponent },
  { path: 'signup', component: NewsLetterFormComponent },
  { path: 'success', component: SuccessMessageComponent },
  // Add more routes as needed
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }