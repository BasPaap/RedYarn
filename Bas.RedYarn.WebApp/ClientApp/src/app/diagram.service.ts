import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Diagram } from './diagram-types';

@Injectable({
  providedIn: 'root'
})
export class DiagramService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  public getDiagram(diagramId: string): Observable<Diagram> {
    return this.httpClient.get<Diagram>(this.baseUrl + `api/diagram/${diagramId}`);
  }

  public createDiagram(name: string) {    
    let returnValue = this.httpClient.post(this.baseUrl + 'api/diagram', name);

    returnValue.subscribe(test => {
      
    }, error => console.error(error));
  }
}


