import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryDiagramComponent } from './story-diagram.component';

describe('StoryDiagramComponent', () => {
  let component: StoryDiagramComponent;
  let fixture: ComponentFixture<StoryDiagramComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StoryDiagramComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StoryDiagramComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
