import { TestBed } from '@angular/core/testing';

import { NetworkItemsConstructorService } from './network-items-constructor.service';

describe('NetworkItemsConstructorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NetworkItemsConstructorService = TestBed.get(NetworkItemsConstructorService);
    expect(service).toBeTruthy();
  });
});
