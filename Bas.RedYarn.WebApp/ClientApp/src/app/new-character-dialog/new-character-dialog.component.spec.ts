import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCharacterDialogComponent } from './new-character-dialog.component';

describe('NewCharacterDialogComponent', () => {
  let component: NewCharacterDialogComponent;
  let fixture: ComponentFixture<NewCharacterDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewCharacterDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewCharacterDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
