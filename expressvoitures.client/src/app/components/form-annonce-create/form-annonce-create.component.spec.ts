import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormAnnonceCreateComponent } from './form-annonce-create.component';

describe('FormAnnonceCreateComponent', () => {
  let component: FormAnnonceCreateComponent;
  let fixture: ComponentFixture<FormAnnonceCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormAnnonceCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormAnnonceCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
