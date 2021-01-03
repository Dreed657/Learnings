import { PostModule } from './../post/post.module';
import { CoreModule } from './../core/core.module';
import { ThemeService } from './theme.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ThemeListItemComponent } from './theme-list-item/theme-list-item.component';
import { ThemeListComponent } from './theme-list/theme-list.component';
import { ThemeComponent } from './theme/theme.component';
import { ThemeRouterModule } from './theme-routing.module';
import { DetailComponent } from './detail/detail.component';
import { SharedModule } from '../shared/shared.module';
import { NewComponent } from './new/new.component';

@NgModule({
  declarations: [
    ThemeListComponent,
    ThemeListItemComponent,
    ThemeComponent,
    DetailComponent,
    NewComponent,
  ],
  imports: [
    CommonModule,
    CoreModule,
    PostModule,
    SharedModule,
    ThemeRouterModule,
  ],
  providers: [
    ThemeService
  ],
  exports: [
    ThemeListComponent,
    ThemeListItemComponent
  ]
})
export class ThemeModule { }
