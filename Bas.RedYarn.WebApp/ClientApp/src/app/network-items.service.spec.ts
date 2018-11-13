import { TestBed } from '@angular/core/testing';

import { NetworkItemsService } from './network-items.service';

describe('NetworkItemsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NetworkItemsService = TestBed.get(NetworkItemsService);
    expect(service).toBeTruthy();
  });
});
