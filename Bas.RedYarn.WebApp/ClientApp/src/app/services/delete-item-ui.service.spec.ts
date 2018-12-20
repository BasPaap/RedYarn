import { TestBed } from '@angular/core/testing';

import { DeleteItemUiService } from './delete-item-ui.service';

describe('DeleteItemUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DeleteItemUiService = TestBed.get(DeleteItemUiService);
    expect(service).toBeTruthy();
  });
});
