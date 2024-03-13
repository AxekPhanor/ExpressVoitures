import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FormVoitureMajComponent } from './form-voiture-maj.component';

describe('FormVoitureMajComponent', () => {
  let component: FormVoitureMajComponent;
  let fixture: ComponentFixture<FormVoitureMajComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FormVoitureMajComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FormVoitureMajComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
