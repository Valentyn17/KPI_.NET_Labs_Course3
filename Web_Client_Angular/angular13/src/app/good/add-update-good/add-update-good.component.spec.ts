import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddUpdateGoodComponent } from './add-update-good.component';

describe('AddUpdateGoodComponent', () => {
  let component: AddUpdateGoodComponent;
  let fixture: ComponentFixture<AddUpdateGoodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddUpdateGoodComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddUpdateGoodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
