import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegcliComponent } from './regcli.component';

describe('RegcliComponent', () => {
  let component: RegcliComponent;
  let fixture: ComponentFixture<RegcliComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegcliComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegcliComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
