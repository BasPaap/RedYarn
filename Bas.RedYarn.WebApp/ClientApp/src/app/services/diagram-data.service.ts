import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Guid } from '../../Guid';
import { Character, Diagram, PlotElement, Relationship, Storyline, Connection, CharacterPlotElementConnection } from '../diagram-types';


// Handles all communication with the REST API and provides observables for updates in existing nodes and connections.
@Injectable({
  providedIn: 'root'
})
export class DiagramDataService {

  private newCharacterSubject = new Subject<Character>();
  private newStorylineSubject = new Subject<Storyline>();
  private newPlotElementSubject = new Subject<PlotElement>();
  private newRelationshipSubject = new Subject<Relationship>();
  private newStorylineCharacterConnectionSubject = new Subject<Connection>();
  private newStorylinePlotElementConnectionSubject = new Subject<Connection>();
  private newCharacterPlotElementConnectionSubject = new Subject<CharacterPlotElementConnection>();
  private updatedCharacterSubject = new Subject<Character>();
  private updatedStorylineSubject = new Subject<Storyline>();
  private updatedPlotElementSubject = new Subject<PlotElement>();
  private updatedRelationshipSubject = new Subject<Relationship>();
  private updatedStorylineCharacterConnectionSubject = new Subject<Connection>();
  private updatedStorylinePlotElementConnectionSubject = new Subject<Connection>();
  private updatedCharacterPlotElementConnectionSubject = new Subject<CharacterPlotElementConnection>();


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

  public get addedStorylineCharacterConnectionsStream(): Observable<Connection> {
    return this.newStorylineCharacterConnectionSubject.asObservable();
  }

  public get addedStorylinePlotElementConnectionsStream(): Observable<Connection> {
    return this.newStorylinePlotElementConnectionSubject.asObservable();
  }

  public get addedCharacterPlotElementConnectionsStream(): Observable<CharacterPlotElementConnection> {
    return this.newCharacterPlotElementConnectionSubject.asObservable();
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

  public get updatedStorylineCharacterConnectionsStream(): Observable<Connection> {
    return this.updatedStorylineCharacterConnectionSubject.asObservable();
  }

  public get updatedStorylinePlotElementConnectionsStream(): Observable<Connection> {
    return this.updatedStorylinePlotElementConnectionSubject.asObservable();
  }

  public get updatedCharacterPlotElementConnectionsStream(): Observable<CharacterPlotElementConnection> {
    return this.updatedCharacterPlotElementConnectionSubject.asObservable();
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

  private createConnection<T>(controllerName: string, viewModel: T, subject: Subject<T>): Observable<T> {
    let observable = this.httpClient.post<T>(`${this.apiUrl}${controllerName}`, viewModel).pipe(
      tap(model => subject.next(model))
    );

    return observable;
  }


  public createRelationship(viewModel: Relationship): Observable<Relationship> {
    return this.createConnection('relationship', viewModel, this.newRelationshipSubject);
  }

  public createStorylineCharacterConnection(viewModel: Connection): Observable<Connection> {
    return this.createConnection('storylinecharacterconnection', viewModel, this.newStorylineCharacterConnectionSubject);
  }

  public createStorylinePlotElementConnection(viewModel: Connection): Observable<Connection> {
    return this.createConnection('storylineplotelementconnection', viewModel, this.newStorylinePlotElementConnectionSubject);
  }

  public createCharacterPlotElementConnection(viewModel: CharacterPlotElementConnection): Observable<CharacterPlotElementConnection> {
    return this.createConnection('characterplotelementconnection', viewModel, this.newCharacterPlotElementConnectionSubject);
  }


  public updateCharacter(characterViewModel: Character): Observable<Character> {
    return this.updateNodeItem("character", characterViewModel, this.updatedCharacterSubject);
  }

  public updateStoryline(storylineViewModel: Storyline): Observable<Storyline> {
    return this.updateNodeItem("storyline", storylineViewModel, this.updatedStorylineSubject);
  }

  public updatePlotElement(plotElementViewModel: PlotElement): Observable<PlotElement> {
    return this.updateNodeItem("PlotElement", plotElementViewModel, this.updatedPlotElementSubject);
  }

  private updateNodeItem<T extends Character | Storyline | PlotElement>(controllerName: string, viewModel: T, subject: Subject<T>): Observable<T> {
    let observable = this.httpClient.put<T>(`${this.apiUrl}${controllerName}/${viewModel.id}`, viewModel).pipe(
      tap(_ => subject.next(viewModel)) // Put operations return no value so we don't need any arguments here, just send the node we sent to the server to the stream.
    );

    return observable;
  }


  private updateConnection<T extends Relationship | Connection | CharacterPlotElementConnection>(controllerName: string, viewModel: T, subject: Subject<T>): Observable<T> {
    let observable = this.httpClient.put<T>(`${this.apiUrl}${controllerName}/${viewModel.id}`, viewModel).pipe(
      tap(_ => subject.next(viewModel))
    );

    return observable;
  }

  public updateRelationship(viewModel: Relationship): Observable<Relationship> {
    return this.updateConnection('relationship', viewModel, this.newRelationshipSubject);
  }

  public updateStorylineCharacterConnection(viewModel: Connection): Observable<Connection> {
    return this.updateConnection('storylinecharacterconnection', viewModel, this.newStorylineCharacterConnectionSubject);
  }

  public updateStorylinePlotElementConnection(viewModel: Connection): Observable<Connection> {
    return this.updateConnection('storylineplotelementconnection', viewModel, this.newStorylinePlotElementConnectionSubject);
  }

  public updateCharacterPlotElementConnection(viewModel: CharacterPlotElementConnection): Observable<CharacterPlotElementConnection> {
    return this.updateConnection('characterplotelementconnection', viewModel, this.newCharacterPlotElementConnectionSubject);
  }
}
