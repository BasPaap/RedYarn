import { TestBed } from '@angular/core/testing';

import { ReadItemUiService } from './read-item-ui.service';

describe('ReadItemUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ReadItemUiService = TestBed.get(ReadItemUiService);
    expect(service).toBeTruthy();
  });
});
