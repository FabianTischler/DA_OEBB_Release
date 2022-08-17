import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFunctionComponent } from './show-function.component';

describe('ShowFunctionComponent', () => {
  let component: ShowFunctionComponent;
  let fixture: ComponentFixture<ShowFunctionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowFunctionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowFunctionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
