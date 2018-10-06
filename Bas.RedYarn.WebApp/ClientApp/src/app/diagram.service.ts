import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DiagramService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  public getDiagram(diagramId: number): Observable<any> {
    return this.httpClient.get(this.baseUrl + `api/Diagrams/${diagramId}`);
  }
}
