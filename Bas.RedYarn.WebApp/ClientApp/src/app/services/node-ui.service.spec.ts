import { TestBed } from '@angular/core/testing';

import { NodeUiService } from './node-ui.service';

describe('NodeUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NodeUiService = TestBed.get(NodeUiService);
    expect(service).toBeTruthy();
  });
});
