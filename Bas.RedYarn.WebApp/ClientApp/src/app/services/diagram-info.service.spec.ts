import { TestBed } from '@angular/core/testing';

import { DiagramInfoService } from './diagram-info.service';

describe('DiagramInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DiagramInfoService = TestBed.get(DiagramInfoService);
    expect(service).toBeTruthy();
  });
});
