import { TestBed } from '@angular/core/testing';

import { VisNetworkGeneratorService } from './vis-network-generator.service';

describe('VisNetworkGeneratorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: VisNetworkGeneratorService = TestBed.get(VisNetworkGeneratorService);
    expect(service).toBeTruthy();
  });
});
