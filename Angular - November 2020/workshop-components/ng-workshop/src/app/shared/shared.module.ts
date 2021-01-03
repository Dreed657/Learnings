import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IsEmptyDirective } from './is-empty.directive';
import { LoaderComponent } from './loader/loader.component';

@NgModule({
  declarations: [
    IsEmptyDirective, 
    LoaderComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    IsEmptyDirective,
    LoaderComponent
  ]
})
export class SharedModule { }
