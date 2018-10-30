import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Diagram, Character } from './diagram-types';

@Injectable({
  providedIn: 'root'
})
export class DiagramService {

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string) {
  }

  public getDiagram(diagramId: string): Observable<Diagram> {
    return this.httpClient.get<Diagram>(this.apiUrl + `diagram/${diagramId}`);
  }

  public createDiagram(name: string): Observable<Diagram> {
    
    let diagramViewModel = {
      id:"00000000-0000-0000-0000-000000000000",
      name: "",
      characters: null,
      storylines: null,
      plotElements: null,
      relationships: null,
      storylineCharacterConnections: null,
      storylinePlotElementConnections: null,
      characterPlotElementConnections: null,
    };

    diagramViewModel.name = name;
    
    return this.httpClient.post<Diagram>(this.apiUrl + 'diagram', diagramViewModel);      
  }

  public createCharacter(characterViewModel: Character): Observable<Character> {
    return this.httpClient.post<Character>(this.apiUrl + 'character', characterViewModel);
  }
}
