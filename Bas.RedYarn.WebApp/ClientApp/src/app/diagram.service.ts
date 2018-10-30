import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Diagram, Character, Storyline } from './diagram-types';
import { StoryDiagramComponent } from './story-diagram/story-diagram.component';

@Injectable({
  providedIn: 'root'
})
export class DiagramService {

  private characterSubject = new Subject<Character>();
  private storylineSubject = new Subject<Storyline>();

  charactersService(): Observable<Character> {
    return this.characterSubject.asObservable();
  }

  storylinesService(): Observable<Storyline> {
    return this.storylineSubject.asObservable();
  }

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
    var observable = this.httpClient.post<Character>(this.apiUrl + 'character', characterViewModel);
    observable.subscribe(character => this.characterSubject.next(character));
    return observable;
  }

  public createStoryline(storylineViewModel: Storyline): Observable<Storyline> {
    var observable = this.httpClient.post<Storyline>(this.apiUrl + 'storyline', storylineViewModel);
    observable.subscribe(storyline => this.storylineSubject.next(storyline));
    return observable;
  }
}
