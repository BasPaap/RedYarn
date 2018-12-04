import { TestBed } from '@angular/core/testing';

import { DiagramDataService } from './diagram-data.service';

describe('DiagramDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DiagramDataService = TestBed.get(DiagramDataService);
    expect(service).toBeTruthy();
  });
});
