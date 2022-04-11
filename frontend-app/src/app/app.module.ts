import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { BodyComponent } from './body/body.component';
import { TopMenuComponent } from './body/top-menu/top-menu.component';
import { MenuBarComponent } from './body/top-menu/menu-bar/menu-bar.component';
import { MenuPesquisaComponent } from './body/top-menu/menu-pesquisa/menu-pesquisa.component';
import { ContentBodyComponent } from './body/content/content-body/content-body.component';
import { ContentComponent } from './body/content/content.component';
import { ContentLeftMenuComponent } from './body/content/content-left-menu/content-left-menu.component';
//globalização
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';  
import { TranslateHttpLoader } from '@ngx-translate/http-loader';  
import { HttpClient } from '@angular/common/http'; 
//paginacao
import { NgxPaginationModule } from 'ngx-pagination';
import { HttpClientModule } from '@angular/common/http';
import { GridClientComponent } from '../CustomComponents/grid-client/grid-client.component';
import { HomeComponent } from './body/content/content-body/home/home.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { RegcliComponent } from './body/content/content-body/regcli/regcli.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    BodyComponent,
    TopMenuComponent,
    MenuBarComponent,
    MenuPesquisaComponent,
    ContentBodyComponent, 
    ContentLeftMenuComponent,
    ContentComponent,
    GridClientComponent,
    NotfoundComponent,
    HomeComponent,
    RegcliComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgxPaginationModule,
    HttpClientModule,  
    TranslateModule.forRoot({  
      loader: {  
          provide: TranslateLoader,  
          useFactory: TranslateHttpLoader,  
          deps: [HttpClient]  
          }  
      })  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
// AOT compilation support  
export function httpTranslateLoader(http: HttpClient) {  
    return new TranslateHttpLoader(http);  
}  
