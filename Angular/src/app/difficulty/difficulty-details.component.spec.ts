import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DifficultyDetailsComponent } from './difficulty-details.component';

describe('DifficultyDetailsComponent', () => {
  let component: DifficultyDetailsComponent;
  let fixture: ComponentFixture<DifficultyDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DifficultyDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DifficultyDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
