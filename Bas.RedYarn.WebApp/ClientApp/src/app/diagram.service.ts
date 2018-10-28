import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Diagram } from './diagram-types';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DiagramService {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) {
  }

  public getDiagram(diagramId: string): Observable<Diagram> {
    return this.httpClient.get<Diagram>(this.baseUrl + `api/diagram/${diagramId}`);
  }

  public createDiagram(name: string) {
    
    let diagramViewModel: Diagram = {
      id: "",
      name: name,
      characters: null,
      storylines: null,
      plotElements: null,
      relationships: null,
      storylineCharacterConnections: null,
      storylinePlotElementConnections: null,
      characterPlotElementConnections: null
    };

    let returnValue = this.httpClient.post(this.baseUrl + 'api/diagram', diagramViewModel);
    returnValue.subscribe(result => {
      this.router.navigate(['diagrams', (result as Diagram).id]);
    }, error => console.error(error));
  }
}
