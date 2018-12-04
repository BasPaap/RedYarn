import { TestBed } from '@angular/core/testing';

import { NewRelationshipUIService } from './new-relationship-ui.service';

describe('NewRelationshipUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NewRelationshipUIService = TestBed.get(NewRelationshipUIService);
    expect(service).toBeTruthy();
  });
});
