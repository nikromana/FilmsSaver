import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LangSelectComponent } from './lang-select.component';

describe('LangSelectComponent', () => {
  let component: LangSelectComponent;
  let fixture: ComponentFixture<LangSelectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LangSelectComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LangSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
