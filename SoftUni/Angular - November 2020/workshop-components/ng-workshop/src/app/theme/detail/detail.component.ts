import { ThemeService } from './../theme.service';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { IPost, ITheme } from 'src/app/shared/interfaces';
import { ActivatedRoute } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { interval, Subscription } from 'rxjs';

@Component({
  selector: 'app-detail',
  templateUrl: './detail.component.html',
  styleUrls: ['./detail.component.css']
})
export class DetailComponent implements OnInit, OnDestroy {

  count = 1;
  timerSubscription: Subscription;
  theme: ITheme<IPost> = null;

  constructor(private title: Title, private activatedRoute: ActivatedRoute, private themeService: ThemeService) {}

  ngOnDestroy(): void {
    this.timerSubscription.unsubscribe();
  }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.params.id;
    this.themeService.loadTheme(id).subscribe(theme => {
        this.title.setTitle(theme.themeName);
        this.theme = theme;
      });

    this.timerSubscription = interval(1000).subscribe(x => {
      this.title.setTitle(`(${this.count}) ${this.theme.themeName}`);
      this.count++;
    });
  }

}
