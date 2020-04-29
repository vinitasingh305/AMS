import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListOfCustomerComponent } from './list-of-customer.component';

describe('ListOfCustomerComponent', () => {
  let component: ListOfCustomerComponent;
  let fixture: ComponentFixture<ListOfCustomerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListOfCustomerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListOfCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
