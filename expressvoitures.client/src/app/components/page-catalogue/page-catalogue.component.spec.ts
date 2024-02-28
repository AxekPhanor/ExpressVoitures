import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PageCatalogueComponent } from './page-catalogue.component';

describe('PageCatalogueComponent', () => {
  let component: PageCatalogueComponent;
  let fixture: ComponentFixture<PageCatalogueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PageCatalogueComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PageCatalogueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
