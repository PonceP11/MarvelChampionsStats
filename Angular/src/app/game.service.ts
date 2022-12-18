import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {catchError, Observable, of, tap} from 'rxjs';
import { Game } from './game';
import { MessageService } from './message.service';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  constructor( private http: HttpClient,
               private messageService: MessageService) { }

  private url = 'http://localhost:5239/game';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private log(message: string) {
    this.messageService.add(`GameService: ${message}`);
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

  getAll(): Observable<Game[]> {
    return this.http.get<Game []>(this.url)
      .pipe(
        tap(_ => this.log('fetched contents')),
        catchError(this.handleError<Game[]>('getcontents', []))
      );
  }

  get(id: number): Observable<Game> {
    const url = `${this.url}/${id}`;
    return this.http.get<Game>(url).pipe(
      tap(_ => this.log(`fetched content id=${id}`)),
      catchError(this.handleError<Game>(`getContent id=${id}`))
    );
  }

  updateItem(item: Game): Observable<any> {
    return this.http.put(`${this.url}/${item.id}`, item, this.httpOptions).pipe(
      tap(_ => this.log(`updated content id=${item.id}`)),
      catchError(this.handleError<any>('update Game'))
    );
  }

  addItem(item: Game): Observable<Game> {
    return this.http.post<Game>(this.url, item, this.httpOptions).pipe(
      tap((newItem: Game) => this.log(`added item w/ id=${newItem.id}`)),
      catchError(this.handleError<Game>('addContent'))
    );
  }

  deleteItem(id: number): Observable<Game> {
    const url = `${this.url}/${id}`;

    return this.http.delete<Game>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted game id=${id}`)),
      catchError(this.handleError<Game>('deleteGame'))
    );
  }
}
