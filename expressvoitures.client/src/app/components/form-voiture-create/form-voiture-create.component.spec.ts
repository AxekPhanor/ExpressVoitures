import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormVoitureCreateComponent } from './form-voiture-create.component';

describe('FormVoitureComponent', () => {
  let component: FormVoitureCreateComponent;
  let fixture: ComponentFixture<FormVoitureCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormVoitureCreateComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormVoitureCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
