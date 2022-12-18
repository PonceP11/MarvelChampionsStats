import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Content } from './content';
import { MessageService } from './message.service';



@Injectable({
  providedIn: 'root'
})
export class ContentService {

  constructor( private http: HttpClient,
               private messageService: MessageService) { }

  private contentsUrl = 'http://localhost:5239/content';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private log(message: string) {
    this.messageService.add(`ContentService: ${message}`);
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  getContents(): Observable<Content[]> {
    return this.http.get<Content []>(this.contentsUrl)
      .pipe(
        tap(_ => this.log('fetched contents')),
        catchError(this.handleError<Content[]>('getcontents', []))
      );
  }

  getContent(id: number): Observable<Content> {
    const url = `${this.contentsUrl}/${id}`;
    return this.http.get<Content>(url).pipe(
      tap(_ => this.log(`fetched content id=${id}`)),
      catchError(this.handleError<Content>(`getContent id=${id}`))
    );
  }

  updateContent(content: Content): Observable<any> {
    return this.http.put(`${this.contentsUrl}/${content.id}`, content, this.httpOptions).pipe(
      tap(_ => this.log(`updated content id=${content.id}`)),
      catchError(this.handleError<any>('updateContent'))
    );
  }

  addContent(content: Content): Observable<Content> {
    return this.http.post<Content>(this.contentsUrl, content, this.httpOptions).pipe(
      tap((newContent: Content) => this.log(`added content w/ id=${newContent.id}`)),
      catchError(this.handleError<Content>('addContent'))
    );
  }

  deleteContent(id: number): Observable<Content> {
    const url = `${this.contentsUrl}/${id}`;

    return this.http.delete<Content>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted content id=${id}`)),
      catchError(this.handleError<Content>('deleteContent'))
    );
  }
}
