import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteGoodComponent } from './show-delete-good.component';

describe('ShowDeleteGoodComponent', () => {
  let component: ShowDeleteGoodComponent;
  let fixture: ComponentFixture<ShowDeleteGoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteGoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDeleteGoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
