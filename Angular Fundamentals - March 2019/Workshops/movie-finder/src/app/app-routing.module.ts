import { MovieDetailsComponent } from './movie-details/movie-details.component';
import { MoviesComponent } from './movies/movies.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SingleMovieResolver } from './services/resolvers/single-movie.resolver';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'movies'},
  { path: 'movies', component: MoviesComponent },
  { path: 'movies/:id', component: MovieDetailsComponent, resolve: { singleMovie: SingleMovieResolver }}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
