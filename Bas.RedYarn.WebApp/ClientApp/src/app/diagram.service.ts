import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Diagram, Character, Storyline, PlotElement } from './diagram-types';
import { ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class DiagramService {

  private characterSubject = new Subject<Character>();
  private storylineSubject = new Subject<Storyline>();
  private plotElementSubject = new Subject<PlotElement>();

  public charactersService(): Observable<Character> {
    return this.characterSubject.asObservable();
  }

  public storylinesService(): Observable<Storyline> {
    return this.storylineSubject.asObservable();
  }

  public plotElementsService(): Observable<PlotElement> {
    return this.plotElementSubject.asObservable();
  }

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string, private route: ActivatedRoute) {
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
    let diagramId = this.route.snapshot.children[0].params.id;

    var observable = this.httpClient.post<T>(`${this.apiUrl}${controllerName}/${diagramId}`, model).pipe(
      tap(model => subject.next(model))
    );

    return observable;
  }

  public updateCharacter(characterViewModel: Character): Observable<Character> {
    return this.updateNodeItem("character", characterViewModel.id, characterViewModel);
  }

  public updateStoryline(storylineViewModel: Storyline): Observable<Storyline> {
    return this.updateNodeItem("storyline", storylineViewModel.id, storylineViewModel);
  }

  public updatePlotElement(plotElementViewModel: PlotElement): Observable<PlotElement> {
    return this.updateNodeItem("PlotElement", plotElementViewModel.id, plotElementViewModel);
  }

  private updateNodeItem<T>(controllerName: string, id: string, model: T): Observable<T> {
    return this.httpClient.post<T>(`${this.apiUrl}${controllerName}/${id}`, model);
  }
}
