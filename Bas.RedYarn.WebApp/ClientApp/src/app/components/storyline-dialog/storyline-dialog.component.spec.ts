import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StorylineDialogComponent } from './storyline-dialog.component';

describe('StorylineDialogComponent', () => {
  let component: StorylineDialogComponent;
  let fixture: ComponentFixture<StorylineDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StorylineDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StorylineDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
