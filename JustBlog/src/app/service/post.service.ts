import { Guid } from 'guid-typescript';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { Post } from 'src/app/model/post';
import { catchError, retry } from 'rxjs/operators';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PostService {
  constructor(private httpClient: HttpClient) {}

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: 'Bearer ' + localStorage.getItem('jwt'),
    }),
  };

  post(
    title: string,
    shortDescription: string,
    description: string,
    content: string,
    urlSlug: string,
    published: boolean,
    postOn: Date,
    categoryId: Guid,
    tags: Guid[]
  ) {
    return this.httpClient.post<Post>(
      'https://localhost:7158/api/post',
      {
        title,
        shortDescription,
        description,
        content,
        urlSlug,
        published,
        postOn,
        categoryId,
        tags,
      },
      this.httpOptions
    );
  }
  get() {
    return this.httpClient
      .get<Post[]>('https://localhost:7158/api/post', this.httpOptions)
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
