import { TestBed } from '@angular/core/testing';

import { NewRelationshipUiService } from './new-relationship-ui.service';

describe('NewRelationshipUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NewRelationshipUiService = TestBed.get(NewRelationshipUiService);
    expect(service).toBeTruthy();
  });
});
