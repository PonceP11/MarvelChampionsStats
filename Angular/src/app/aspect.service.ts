import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Aspect } from './aspect';
import { MessageService } from './message.service';



@Injectable({
  providedIn: 'root'
})
export class AspectService {

  constructor( private http: HttpClient,
               private messageService: MessageService) { }

  private aspectsUrl = 'http://localhost:5239/aspect';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private log(message: string) {
    this.messageService.add(`AspectService: ${message}`);
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

  getAspects(): Observable<Aspect[]> {
    return this.http.get<Aspect[]>(this.aspectsUrl)
      .pipe(
        tap(_ => this.log('fetched aspects')),
        catchError(this.handleError<Aspect[]>('getAspects', []))
      );
  }

  getAspect(id: number): Observable<Aspect> {
    const url = `${this.aspectsUrl}/${id}`;
    return this.http.get<Aspect>(url).pipe(
      tap(_ => this.log(`fetched aspect id=${id}`)),
      catchError(this.handleError<Aspect>(`getAspect id=${id}`))
    );
  }

  updateAspect(aspect: Aspect): Observable<any> {
    return this.http.put(`${this.aspectsUrl}/${aspect.id}`, aspect, this.httpOptions).pipe(
      tap(_ => this.log(`updated aspect id=${aspect.id}`)),
      catchError(this.handleError<any>('updateAspect'))
    );
  }

  addAspect(aspect: Aspect): Observable<Aspect> {
    return this.http.post<Aspect>(this.aspectsUrl, aspect, this.httpOptions).pipe(
      tap((newAspect: Aspect) => this.log(`added aspect w/ id=${newAspect.id}`)),
      catchError(this.handleError<Aspect>('addAspect'))
    );
  }

  deleteAspect(id: number): Observable<Aspect> {
    const url = `${this.aspectsUrl}/${id}`;

    return this.http.delete<Aspect>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted aspect id=${id}`)),
      catchError(this.handleError<Aspect>('deleteAspect'))
    );
  }
}
