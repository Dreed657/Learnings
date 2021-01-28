import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap, map } from 'rxjs/operators';
import Movie from '../models/Movie';
import MovieDetails from '../models/Movie-Details';

const API_KEY = '&api_key=ed4df42ae398f0e000f5258ab85b3bb4';
const API_KEY_ALT = '?api_key=ed4df42ae398f0e000f5258ab85b3bb4';

const BASE_URL = 'https://api.themoviedb.org/3/';
const POPULAR = 'movie/popular?sort_by=popularity.desc';
const IN_THEATERS = 'discover/movie?with_release_type=2|3';
const KIDS = 'discover/movie?certification_country=US&certification.lte=G&sort_by=popularity.desc';
const BEST_DRAMA = 'discover/movie?with_genres=18&primary_release_year=2020';

@Injectable({
  providedIn: 'root'
})
export class MovieService {
  constructor(private http: HttpClient) { }

  searchMovie(query: string) {
    return this.http.get<Movie[]>(BASE_URL + 'search/movie' + API_KEY_ALT + `&query=${query}`);
  }

  getMovieById(id: string) {
    return this.http.get<MovieDetails>(BASE_URL + `movie/${id}` + API_KEY_ALT)
  }

  getPopularMovies() {
    return this.http.get<Array<Movie>>(BASE_URL + POPULAR + API_KEY)
      .pipe(
        map((data) => data['results'].slice(0, 6))
      );
  }

  getInTheaterMovies() {
    return this.http.get<Array<Movie>>(BASE_URL + IN_THEATERS + API_KEY)
      .pipe(
        map((data) => data['results'].slice(0, 6))
      );
  }

  getPopularKidsMovies() {
    return this.http.get<Movie[]>(BASE_URL + KIDS + API_KEY)
      .pipe(
        map((data) => data['results'].slice(0, 6))
      );
  }

  getBestDramaMovies() {
    return this.http.get<Movie[]>(BASE_URL + BEST_DRAMA + API_KEY)
      .pipe(
        map((data) => data['results'].slice(0, 6))
      );
  }
}
