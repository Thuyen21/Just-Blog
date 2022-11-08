import { Post } from './../model/post';
import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { Category } from '../model/category';
import { Tag } from '../model/tag';

@Injectable({
  providedIn: 'root',
})
export class TagService {
  constructor(private httpClient: HttpClient) {}
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + localStorage.getItem('jwt'),
    }),
  };
  post(name: string, urlSlug: string, description: string) {
    return this.httpClient
      .post<Tag>(
        'https://localhost:7158/api/tag',
        { name, urlSlug, description },
        this.httpOptions
      )
      .pipe(catchError(this.handleError));
  }
  get() {
    return this.httpClient
      .get<Tag[]>('https://localhost:7158/api/tag', this.httpOptions)
      .pipe(catchError(this.handleError));
  }
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `,
        error.error
      );
    }
    // Return an observable with a user-facing error message.
    return throwError(
      () => new Error('Something bad happened; please try again later.')
    );
  }
}
