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

  private newCharacterSubject = new Subject<Character>();
  private newStorylineSubject = new Subject<Storyline>();
  private newPlotElementSubject = new Subject<PlotElement>();
  private updatedCharacterSubject = new Subject<Character>();
  private updatedStorylineSubject = new Subject<Storyline>();
  private updatedPlotElementSubject = new Subject<PlotElement>();

  public get newCharactersStream(): Observable<Character> {
    return this.newCharacterSubject.asObservable();
  }

  public get newStorylinesStream(): Observable<Storyline> {
    return this.newStorylineSubject.asObservable();
  }

  public get newPlotElementsStream(): Observable<PlotElement> {
    return this.newPlotElementSubject.asObservable();
  }

  public get updatedCharactersStream(): Observable<Character> {
    return this.updatedCharacterSubject.asObservable();
  }

  public get updatedStorylinesStream(): Observable<Storyline> {
    return this.updatedStorylineSubject.asObservable();
  }

  public get updatedPlotElementsStream(): Observable<PlotElement> {
    return this.updatedPlotElementSubject.asObservable();
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
    return this.createNodeItem('character', characterViewModel, this.newCharacterSubject);
  }

  public createStoryline(storylineViewModel: Storyline): Observable<Storyline> {
    return this.createNodeItem('storyline', storylineViewModel, this.newStorylineSubject);
  }

  public createPlotElement(plotElementViewModel: PlotElement): Observable<PlotElement> {
    return this.createNodeItem('plotelement', plotElementViewModel, this.newPlotElementSubject);
  }

  private createNodeItem<T>(controllerName: string, model: T, subject: Subject<T>): Observable<T> {
    let diagramId = this.route.snapshot.children[0].params.id;

    var observable = this.httpClient.post<T>(`${this.apiUrl}${controllerName}/${diagramId}`, model).pipe(
      tap(model => subject.next(model))
    );

    return observable;
  }

  public updateCharacter(characterViewModel: Character): Observable<Character> {
    return this.updateNodeItem("character", characterViewModel.id, characterViewModel, this.updatedCharacterSubject);
  }

  public updateStoryline(storylineViewModel: Storyline): Observable<Storyline> {
    return this.updateNodeItem("storyline", storylineViewModel.id, storylineViewModel, this.updatedStorylineSubject);
  }

  public updatePlotElement(plotElementViewModel: PlotElement): Observable<PlotElement> {
    return this.updateNodeItem("PlotElement", plotElementViewModel.id, plotElementViewModel, this.updatedPlotElementSubject);
  }

  private updateNodeItem<T>(controllerName: string, id: string, model: T, subject: Subject<T>): Observable<T> {
    var observable = this.httpClient.put<T>(`${this.apiUrl}${controllerName}/${id}`, model).pipe(
      tap(model => subject.next(model))
    );

    return observable;
  }
}
