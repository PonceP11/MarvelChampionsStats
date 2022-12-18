import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {catchError, Observable, of, tap} from 'rxjs';
import { Difficulty } from './difficulty';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class DifficultyService {

  constructor( private http: HttpClient,
               private messageService: MessageService) { }

  private url = 'http://localhost:5239/difficulty';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private log(message: string) {
    this.messageService.add(`DifficultyService: ${message}`);
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

  getAll(): Observable<Difficulty[]> {
    return this.http.get<Difficulty []>(this.url)
      .pipe(
        tap(_ => this.log('fetched contents')),
        catchError(this.handleError<Difficulty[]>('getcontents', []))
      );
  }

  get(id: number): Observable<Difficulty> {
    const url = `${this.url}/${id}`;
    return this.http.get<Difficulty>(url).pipe(
      tap(_ => this.log(`fetched content id=${id}`)),
      catchError(this.handleError<Difficulty>(`getContent id=${id}`))
    );
  }

  updateItem(item: Difficulty): Observable<any> {
    return this.http.put(`${this.url}/${item.id}`, item, this.httpOptions).pipe(
      tap(_ => this.log(`updated content id=${item.id}`)),
      catchError(this.handleError<any>('update Difficulty'))
    );
  }

  addItem(item: Difficulty): Observable<Difficulty> {
    return this.http.post<Difficulty>(this.url, item, this.httpOptions).pipe(
      tap((newItem: Difficulty) => this.log(`added item w/ id=${newItem.id}`)),
      catchError(this.handleError<Difficulty>('addContent'))
    );
  }

  deleteItem(id: number): Observable<Difficulty> {
    const url = `${this.url}/${id}`;

    return this.http.delete<Difficulty>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted difficulty id=${id}`)),
      catchError(this.handleError<Difficulty>('deleteDifficulty'))
    );
  }
}
