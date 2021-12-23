import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteOrderComponent } from './show-delete-order.component';

describe('ShowDeleteOrderComponent', () => {
  let component: ShowDeleteOrderComponent;
  let fixture: ComponentFixture<ShowDeleteOrderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteOrderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDeleteOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
