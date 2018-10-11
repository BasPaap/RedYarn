import { TestBed } from '@angular/core/testing';

import { DiagramGeneratorService } from './diagram-generator.service';

describe('DiagramGeneratorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DiagramGeneratorService = TestBed.get(DiagramGeneratorService);
    expect(service).toBeTruthy();
  });
});
