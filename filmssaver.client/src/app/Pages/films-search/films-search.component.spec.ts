import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmsSearchComponent } from './films-search.component';

describe('FilmsSearchComponent', () => {
  let component: FilmsSearchComponent;
  let fixture: ComponentFixture<FilmsSearchComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilmsSearchComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FilmsSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
