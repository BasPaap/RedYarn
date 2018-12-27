import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewStorylineDialogComponent } from './new-storyline-dialog.component';

describe('NewStorylineDialogComponent', () => {
  let component: NewStorylineDialogComponent;
  let fixture: ComponentFixture<NewStorylineDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewStorylineDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewStorylineDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
