import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EvaluateErrorComponent } from './evaluate-error.component';

describe('EvaluateErrorComponent', () => {
  let component: EvaluateErrorComponent;
  let fixture: ComponentFixture<EvaluateErrorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EvaluateErrorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EvaluateErrorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
