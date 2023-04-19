import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './modules/admin/admin.component';
 
import { CoreModule } from './core/core.module';
                                                                    
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full',
      }, {
        path: '',
        component: AdminComponent,
        children: [{
          path: '',
          loadChildren: () => import('./modules/admin/admin.module').then(m => m.AdminModule)
        }]
      }])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
