import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFunctionWarmComponent } from './show-function-warm.component';

describe('ShowFunctionWarmComponent', () => {
  let component: ShowFunctionWarmComponent;
  let fixture: ComponentFixture<ShowFunctionWarmComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowFunctionWarmComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowFunctionWarmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
