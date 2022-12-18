import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AspectNewComponent } from './aspect-new.component';

describe('AspectNewComponent', () => {
  let component: AspectNewComponent;
  let fixture: ComponentFixture<AspectNewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AspectNewComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AspectNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
