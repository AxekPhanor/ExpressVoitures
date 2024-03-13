import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAnnonceMajComponent } from './form-annonce-maj.component';

describe('FormAnnonceMajComponent', () => {
  let component: FormAnnonceMajComponent;
  let fixture: ComponentFixture<FormAnnonceMajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormAnnonceMajComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormAnnonceMajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
