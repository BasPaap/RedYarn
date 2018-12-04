import { TestBed } from '@angular/core/testing';

import { NodeLayoutInfoService } from './node-layout-info.service';

describe('NodeLayoutInfoService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NodeLayoutInfoService = TestBed.get(NodeLayoutInfoService);
    expect(service).toBeTruthy();
  });
});
