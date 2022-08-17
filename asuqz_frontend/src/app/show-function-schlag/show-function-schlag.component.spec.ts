import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFunctionSchlagComponent } from './show-function-schlag.component';

describe('ShowFunctionSchlagComponent', () => {
  let component: ShowFunctionSchlagComponent;
  let fixture: ComponentFixture<ShowFunctionSchlagComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowFunctionSchlagComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowFunctionSchlagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
