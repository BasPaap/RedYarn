import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PlotElementDialogComponent } from './plot-element-dialog.component';

describe('PlotElementDialogComponent', () => {
  let component: PlotElementDialogComponent;
  let fixture: ComponentFixture<PlotElementDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PlotElementDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PlotElementDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
