import { UserModule } from './../user/user.module';
import { AuthService } from './auth.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { storageServiceProvider } from './storage.service';
import { RouterModule } from '@angular/router';
import { AuthGuard } from './guards/auth.guard';
import { appInterceptorProvider } from './app.interceptor';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  providers: [
    storageServiceProvider,
    appInterceptorProvider,
    AuthGuard,
    AuthService,
  ],
  exports: [
    HeaderComponent,
    FooterComponent
  ],
})
export class CoreModule { }
