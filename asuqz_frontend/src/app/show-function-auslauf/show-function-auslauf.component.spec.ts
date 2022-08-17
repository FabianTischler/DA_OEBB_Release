import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowFunctionAuslaufComponent } from './show-function-auslauf.component';

describe('ShowFunctionAuslaufComponent', () => {
  let component: ShowFunctionAuslaufComponent;
  let fixture: ComponentFixture<ShowFunctionAuslaufComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowFunctionAuslaufComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowFunctionAuslaufComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
