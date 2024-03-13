import { TestBed } from '@angular/core/testing';

import { VoitureEnregistreService } from './voiture-enregistre.service';

describe('VoitureEnregistreService', () => {
  let service: VoitureEnregistreService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VoitureEnregistreService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
