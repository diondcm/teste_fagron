import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuPesquisaComponent } from './menu-pesquisa.component';

describe('MenuPesquisaComponent', () => {
  let component: MenuPesquisaComponent;
  let fixture: ComponentFixture<MenuPesquisaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuPesquisaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuPesquisaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
