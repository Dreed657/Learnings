import { PostListComponent } from './post-list/post-list.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PostService } from './post.service';

@NgModule({
  declarations: [
    PostListComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    PostService
  ],
  exports: [
    PostListComponent,
  ]
})
export class PostModule { }
