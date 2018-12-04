import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewRelationshipDialogComponent } from './new-relationship-dialog.component';

describe('NewRelationshipDialogComponent', () => {
  let component: NewRelationshipDialogComponent;
  let fixture: ComponentFixture<NewRelationshipDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewRelationshipDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewRelationshipDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
