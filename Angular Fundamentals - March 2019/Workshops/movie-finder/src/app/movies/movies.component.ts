import { Component, OnInit, OnDestroy } from '@angular/core';
import { MovieService } from '../services/movie.service';
import Movie from '../models/Movie';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.css']
})
export class MoviesComponent implements OnInit, OnDestroy {
  popularMovies: Array<Movie>;
  popularMovieSub: Subscription;

  inTheaterMovies: Array<Movie>;
  inTheaterMoviesSub: Subscription;

  kidsMovies: Array<Movie>;
  kidsMoviesSub: Subscription;

  dramaMovies: Array<Movie>;
  dramaMovieSub: Subscription;

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.inTheaterMoviesSub = this.movieService.getInTheaterMovies().subscribe(data => {
      this.inTheaterMovies = data;
    });

    this.popularMovieSub = this.movieService.getPopularMovies().subscribe(data => {
      this.popularMovies = data;
    });

    this.kidsMoviesSub = this.movieService.getPopularKidsMovies().subscribe(data => {
      this.kidsMovies = data;
    });

    this.dramaMovieSub = this.movieService.getBestDramaMovies().subscribe(data => {
      this.dramaMovies = data;
    });
  }

  ngOnDestroy() {
    this.popularMovieSub.unsubscribe();
    this.kidsMoviesSub.unsubscribe();
    this.inTheaterMoviesSub.unsubscribe();
    this.dramaMovieSub.unsubscribe();
  }
}
