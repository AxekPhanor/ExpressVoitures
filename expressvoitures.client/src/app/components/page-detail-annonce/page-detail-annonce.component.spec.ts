import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageDetailAnnonceComponent } from './page-detail-annonce.component';

describe('PageDetailAnnonceComponent', () => {
  let component: PageDetailAnnonceComponent;
  let fixture: ComponentFixture<PageDetailAnnonceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageDetailAnnonceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageDetailAnnonceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
