import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsLetterFormComponent } from './news-letter-form.component';

describe('NewsLetterFormComponent', () => {
  let component: NewsLetterFormComponent;
  let fixture: ComponentFixture<NewsLetterFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewsLetterFormComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NewsLetterFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
