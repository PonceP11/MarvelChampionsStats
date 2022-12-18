import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Scenario } from './scenario';
import { MessageService } from './message.service';



@Injectable({
  providedIn: 'root'
})
export class ScenarioService {

  constructor( private http: HttpClient,
               private messageService: MessageService) { }

  private scenariosUrl = 'http://localhost:5239/scenario';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  private log(message: string) {
    this.messageService.add(`ScenarioService: ${message}`);
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

  getScenarios(): Observable<Scenario[]> {
    return this.http.get<Scenario[]>(this.scenariosUrl)
      .pipe(
        tap(_ => this.log('fetched scenarios')),
        catchError(this.handleError<Scenario[]>('getScenarios', []))
      );
  }

  getScenario(id: number): Observable<Scenario> {
    const url = `${this.scenariosUrl}/${id}`;
    return this.http.get<Scenario>(url).pipe(
      tap(_ => this.log(`fetched scenario id=${id}`)),
      catchError(this.handleError<Scenario>(`getScenario id=${id}`))
    );
  }

  updateScenario(scenario: Scenario): Observable<any> {
    return this.http.put(`${this.scenariosUrl}/${scenario.id}`, scenario, this.httpOptions).pipe(
      tap(_ => this.log(`updated scenario id=${scenario.id}`)),
      catchError(this.handleError<any>('updateScenario'))
    );
  }

  addScenario(scenario: Scenario): Observable<Scenario> {
    return this.http.post<Scenario>(this.scenariosUrl, scenario, this.httpOptions).pipe(
      tap((newScenario: Scenario) => this.log(`added scenario w/ id=${newScenario.id}`)),
      catchError(this.handleError<Scenario>('addScenario'))
    );
  }

  deleteScenario(id: number): Observable<Scenario> {
    const url = `${this.scenariosUrl}/${id}`;

    return this.http.delete<Scenario>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted scenario id=${id}`)),
      catchError(this.handleError<Scenario>('deleteScenario'))
    );
  }

  searchScenarios(term: string): Observable<Scenario[]> {
    if (!term.trim()) {
      return of([]);
    }
    return this.http.get<Scenario[]>(`${this.scenariosUrl}/?name=${term}`).pipe(
      tap(x => x.length ?
        this.log(`found scenarios matching "${term}"`) :
        this.log(`no scenarios matching "${term}"`)),
      catchError(this.handleError<Scenario[]>('searchScenarios', []))
    );
  }
}
