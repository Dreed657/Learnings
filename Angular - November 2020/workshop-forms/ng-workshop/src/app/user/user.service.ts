import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IUser } from '../shared/interfaces';
import { tap } from 'rxjs/operators';
import { AuthService } from '../core/auth.service';

@Injectable()
export class UserService {

  constructor(private http: HttpClient, private authService: AuthService) { }

  getCurrentUserProfile(): Observable<any> {
    return this.http.get(`/users/profile`).pipe(
      tap((user: IUser) => this.authService.updateCurrentUser(user))
    );
  }

  updateProfile(data: any): Observable<IUser> {
    return this.http.put(`/users/profile`, data).pipe(
      tap((user: IUser) => this.authService.updateCurrentUser(user))
    );
  }
}
