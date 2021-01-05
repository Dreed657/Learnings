import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { environment } from '../../environments/environment';
import { IUser } from '../shared/interfaces';

const apiUrl = environment.apiUrl;

@Injectable()
export class UserService {

  currentUser: IUser;

  get isLogged(): boolean {
    return !!this.currentUser;
  }

  constructor(private http: HttpClient) {}

  getCurrentUserProfile(): Observable<any> {
    return this.http.get(`${apiUrl}/users/profile`, { withCredentials: true })
      .pipe(
        tap((user: IUser) => this.currentUser = user),
        catchError(() => { this.currentUser = null; return of(null)})
      );
  }
}
