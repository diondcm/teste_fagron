import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContentLeftMenuComponent } from './content-left-menu.component';

describe('ContentLeftMenuComponent', () => {
  let component: ContentLeftMenuComponent;
  let fixture: ComponentFixture<ContentLeftMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContentLeftMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContentLeftMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
