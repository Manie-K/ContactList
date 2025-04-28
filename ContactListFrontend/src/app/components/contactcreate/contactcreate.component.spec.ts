import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactcreateComponent } from './contactcreate.component';

describe('ContactcreateComponent', () => {
  let component: ContactcreateComponent;
  let fixture: ComponentFixture<ContactcreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContactcreateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContactcreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
