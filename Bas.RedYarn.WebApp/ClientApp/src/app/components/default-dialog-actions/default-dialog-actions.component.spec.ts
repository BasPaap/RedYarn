import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultDialogActionsComponent } from './default-dialog-actions.component';

describe('DefaultDialogActionsComponent', () => {
  let component: DefaultDialogActionsComponent;
  let fixture: ComponentFixture<DefaultDialogActionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DefaultDialogActionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DefaultDialogActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
