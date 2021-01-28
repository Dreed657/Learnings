import { Directive, DoCheck, Input } from '@angular/core';

@Directive({
  selector: '[appIsEmpty]',
  exportAs: 'isEmpty'
})
export class IsEmptyDirective implements DoCheck {

  @Input() someValue: any;

  isEmpty = true;

  constructor() { }

  ngDoCheck(): void {
    this.isEmpty = !this.someValue;
  }

}
