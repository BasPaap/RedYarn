import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPlotElementDialogComponent } from './new-plot-element-dialog.component';

describe('NewPlotElementDialogComponent', () => {
  let component: NewPlotElementDialogComponent;
  let fixture: ComponentFixture<NewPlotElementDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NewPlotElementDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NewPlotElementDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
