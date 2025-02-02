import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilmsSavedComponent } from './films-saved.component';

describe('FilmsSavedComponent', () => {
  let component: FilmsSavedComponent;
  let fixture: ComponentFixture<FilmsSavedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilmsSavedComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FilmsSavedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
