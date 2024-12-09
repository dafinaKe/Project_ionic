import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TravelexPage } from './travelex.page';

describe('TravelexPage', () => {
  let component: TravelexPage;
  let fixture: ComponentFixture<TravelexPage>;

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelexPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
