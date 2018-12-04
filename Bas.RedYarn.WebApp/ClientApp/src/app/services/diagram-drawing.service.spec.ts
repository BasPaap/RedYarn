import { TestBed } from '@angular/core/testing';

import { DiagramDrawingService } from './diagram-drawing.service';

describe('DiagramDrawingService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DiagramDrawingService = TestBed.get(DiagramDrawingService);
    expect(service).toBeTruthy();
  });
});
