import { TestBed } from '@angular/core/testing';

import { NewConnectionUIService } from './new-connection-ui.service';

describe('NewRelationshipUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NewConnectionUIService = TestBed.get(NewConnectionUIService);
    expect(service).toBeTruthy();
  });
});
