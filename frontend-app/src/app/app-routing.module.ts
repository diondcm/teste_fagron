import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './body/content/content-body/home/home.component';
import { RegcliComponent } from './body/content/content-body/regcli/regcli.component';
import { NotfoundComponent } from './notfound/notfound.component';

const routes: Routes = [
  {
    path: '**',
    component: NotfoundComponent
  },  
  {    
    path: 'regcli',
    component: RegcliComponent
  },
  {
    path: '',
    component: HomeComponent
  },  
  {
      path: 'home',
      component: HomeComponent
  },  
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
