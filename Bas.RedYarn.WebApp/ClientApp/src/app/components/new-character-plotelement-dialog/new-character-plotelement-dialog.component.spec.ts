import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCharacterPlotelementDialogComponent } from './new-character-plotelement-dialog.component';

describe('NewCharacterPlotelementDialogComponent', () => {
  let component: NewCharacterPlotelementDialogComponent;
  let fixture: ComponentFixture<NewCharacterPlotelementDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewCharacterPlotelementDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewCharacterPlotelementDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
