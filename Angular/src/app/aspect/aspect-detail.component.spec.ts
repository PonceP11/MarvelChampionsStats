import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AspectDetailComponent } from './aspect-detail.component';

describe('AspectDetailComponent', () => {
  let component: AspectDetailComponent;
  let fixture: ComponentFixture<AspectDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AspectDetailComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AspectDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
