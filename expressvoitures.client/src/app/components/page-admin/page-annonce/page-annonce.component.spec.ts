import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageAnnonceComponent } from './page-annonce.component';

describe('PageAnnonceComponent', () => {
  let component: PageAnnonceComponent;
  let fixture: ComponentFixture<PageAnnonceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageAnnonceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageAnnonceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
