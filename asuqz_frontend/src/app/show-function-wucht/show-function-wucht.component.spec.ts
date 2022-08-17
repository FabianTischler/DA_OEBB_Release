import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFunctionWuchtComponent } from './show-function-wucht.component';

describe('ShowFunctionWuchtComponent', () => {
  let component: ShowFunctionWuchtComponent;
  let fixture: ComponentFixture<ShowFunctionWuchtComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowFunctionWuchtComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowFunctionWuchtComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
