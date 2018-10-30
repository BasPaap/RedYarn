import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { Diagram, Character, Storyline, PlotElement } from './diagram-types';

@Injectable({
  providedIn: 'root'
})
export class DiagramService {

  private characterSubject = new Subject<Character>();
  private storylineSubject = new Subject<Storyline>();
  private plotElementSubject = new Subject<PlotElement>();

  charactersService(): Observable<Character> {
    return this.characterSubject.asObservable();
  }

  storylinesService(): Observable<Storyline> {
    return this.storylineSubject.asObservable();
  }

  plotElementsService(): Observable<PlotElement> {
    return this.plotElementSubject.asObservable();
  }

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string) {
  }

  public getDiagram(diagramId: string): Observable<Diagram> {
    return this.httpClient.get<Diagram>(this.apiUrl + `diagram/${diagramId}`);
  }

  public createDiagram(name: string): Observable<Diagram> {

    let diagramViewModel = {
      id: "00000000-0000-0000-0000-000000000000",
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
    return this.createNodeItem('character', characterViewModel, this.characterSubject);
  }

  public createStoryline(storylineViewModel: Storyline): Observable<Storyline> {
    return this.createNodeItem('storyline', storylineViewModel, this.storylineSubject);
  }

  public createPlotElement(plotElementViewModel: PlotElement): Observable<PlotElement> {
    return this.createNodeItem('plotelement', plotElementViewModel, this.plotElementSubject);
  }
  
  private createNodeItem<T>(controllerName: string, model: T, subject: Subject<T>): Observable<T> {
    var observable = this.httpClient.post<T>(this.apiUrl + controllerName, model);
    observable.subscribe(model => subject.next(model));
    return observable;
  }
}
