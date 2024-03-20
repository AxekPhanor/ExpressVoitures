import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogModifierPasswordComponent } from './dialog-modifier-password.component';

describe('DialogModifierPasswordComponent', () => {
  let component: DialogModifierPasswordComponent;
  let fixture: ComponentFixture<DialogModifierPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogModifierPasswordComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DialogModifierPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
