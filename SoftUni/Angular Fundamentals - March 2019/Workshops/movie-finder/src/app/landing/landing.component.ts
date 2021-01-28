import { MovieService } from './../services/movie.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import Movie from '../models/Movie';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {
  @ViewChild('f') searchForm: NgForm;
  searchedMovies: Movie[];

  constructor(private movieService: MovieService) { }

  ngOnInit(): void {
  }

  Search() {
    const query = this.searchForm.value.query;
    this.movieService.searchMovie(query).subscribe(data => {
      this.searchedMovies = data['results'];
    });
  }
}
