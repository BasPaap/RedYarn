import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Guid } from '../../Guid';
import { Character, Diagram, PlotElement, Relationship, Storyline } from '../diagram-types';


// Handles all communication with the REST API and provides observables for updates in existing nodes and connections.
@Injectable({
  providedIn: 'root'
})
export class DiagramDataService {

  private newCharacterSubject = new Subject<Character>();
  private newStorylineSubject = new Subject<Storyline>();
  private newPlotElementSubject = new Subject<PlotElement>();
  private newRelationshipSubject = new Subject<Relationship>();
  private updatedCharacterSubject = new Subject<Character>();
  private updatedStorylineSubject = new Subject<Storyline>();
  private updatedPlotElementSubject = new Subject<PlotElement>();
  private updatedRelationshipSubject = new Subject<Relationship>();


  public get addedCharactersStream(): Observable<Character> {
    return this.newCharacterSubject.asObservable();
  }

  public get addedStorylinesStream(): Observable<Storyline> {
    return this.newStorylineSubject.asObservable();
  }

  public get addedPlotElementsStream(): Observable<PlotElement> {
    return this.newPlotElementSubject.asObservable();
  }

  public get addedRelationshipsStream(): Observable<Relationship> {
    return this.newRelationshipSubject.asObservable();
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

  public get updatedRelationshipsStream(): Observable<Relationship> {
    return this.updatedRelationshipSubject.asObservable();
  }


  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string, private route: ActivatedRoute) {
  }

  public getDiagram(diagramId: string): Observable<Diagram> {
    let observable = this.httpClient.get<Diagram>(this.apiUrl + `diagram/${diagramId}`).pipe(
      tap(diagram => {
        for (let character of diagram.characters) {
          this.newCharacterSubject.next(character);
        }

        for (let storyline of diagram.storylines) {
          this.newStorylineSubject.next(storyline);
        }

        for (let plotElement of diagram.plotElements) {
          this.newPlotElementSubject.next(plotElement);
        }

        for (let relationship of diagram.relationships) {
          this.newRelationshipSubject.next(relationship);
        }
      })
    );

    return observable;
  }

  public createDiagram(name: string): Observable<Diagram> {
    let diagramViewModel = {
      id: Guid.empty,
      name: name,
      characters: null,
      storylines: null,
      plotElements: null,
      relationships: null,
      storylineCharacterConnections: null,
      storylinePlotElementConnections: null,
      characterPlotElementConnections: null,
    };
        
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

    let observable = this.httpClient.post<T>(`${this.apiUrl}${controllerName}/${diagramId}`, model).pipe(
      tap(model => subject.next(model))
    );

    return observable;
  }


  public createRelationship(relationshipViewModel: Relationship): Observable<Relationship> {
    let observable = this.httpClient.post<Relationship>(`${this.apiUrl}relationship`, relationshipViewModel).pipe(
      tap(model => this.newRelationshipSubject.next(relationshipViewModel))
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
    let observable = this.httpClient.put<T>(`${this.apiUrl}${controllerName}/${id}`, model).pipe(
      tap(_ => subject.next(model)) // Put operations return no value so we don't need any arguments here, just send the node we sent to the server to the stream.
    );

    return observable;
  }

  public updateRelationship(relationshipViewModel: Relationship): Observable<Relationship> {
    let observable = this.httpClient.put<Relationship>(`${this.apiUrl}relationship/${relationshipViewModel.fromNodeId}/${relationshipViewModel.toNodeId}`, relationshipViewModel).pipe(
      tap(_ => this.updatedRelationshipSubject.next(relationshipViewModel))
    );

    return observable;
  }
}
