import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPost } from '../shared/interfaces/post';

@Injectable()
export class PostService {

  constructor(private http: HttpClient) { }

  loadPostList(themeId: string, limit?: number): Observable<IPost[]> {
    return this.http.get<IPost[]>(
      `/posts${limit ? `?limit=${limit}` : ''}`
    );
  }
}
