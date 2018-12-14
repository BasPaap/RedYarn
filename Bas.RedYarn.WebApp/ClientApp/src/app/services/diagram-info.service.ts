import { Injectable, OnDestroy } from '@angular/core';
import { Subscription, Observable } from 'rxjs';
import { DiagramDataService } from './diagram-data.service';
import { Character, Storyline, PlotElement, Relationship, DiagramItemType, Connection, CharacterPlotElementConnection } from '../diagram-types';

// Provides information about the characters, storylines, relationships etc. in the current diagram.
@Injectable({
  providedIn: 'root'
})
export class DiagramInfoService implements OnDestroy {
  private subscriptions: { [name: string]: Subscription; } = {};
  private characters: { [id: string]: Character } = {};
  private plotElements: { [id: string]: PlotElement } = {};
  private storylines: { [id: string]: Storyline } = {};
  private relationships: { [id: string]: Relationship } = {};
  private storylineCharacterConnections: { [id: string]: Connection } = {};
  private storylinePlotElementConnections: { [id: string]: Connection } = {};
  private characterPlotElementConnections: { [id: string]: CharacterPlotElementConnection } = {};

  private diagramItemTypes: { [id: string]: DiagramItemType } = {};

  private subscribe<T extends Character | PlotElement | Storyline | Relationship >(service: Observable<T>, itemType: DiagramItemType, array: { [id: string]: T; }): Subscription {
    return service.subscribe(item => {
      array[item.id] = item;
      this.diagramItemTypes[item.id] = itemType;
    })
  }

  private subscribeConnection<T extends Connection | CharacterPlotElementConnection>(service: Observable<T>, itemType: DiagramItemType, array: { [id: string]: T; }): Subscription {
    return service.subscribe(item => {
      array[`${item.fromNodeId}-${item.toNodeId}`] = item;
      this.diagramItemTypes[`${item.fromNodeId}-${item.toNodeId}`] = itemType;
    })
  }

  public getItemType(id: string): DiagramItemType {
    return (this.diagramItemTypes[id]) ? this.diagramItemTypes[id] : DiagramItemType.Unknown;
  }

  public getConnectionItemType(fromId: string, toId: string): DiagramItemType {
    return (this.diagramItemTypes[`${fromId}-${toId}`]) ? this.diagramItemTypes[`${fromId}-${toId}`] : DiagramItemType.Unknown;
  }

  public getCharacter(id: string): Character {
    return this.characters[id];
  }

  public getPlotElement(id: string): PlotElement {
    return this.plotElements[id];
  }

  constructor(private diagramDataService: DiagramDataService) { }

  public initialize() {
    this.reset();

    this.subscriptions['newCharacter'] = this.subscribe(this.diagramDataService.addedCharactersStream, DiagramItemType.Character, this.characters);
    this.subscriptions['newStoryline'] = this.subscribe(this.diagramDataService.addedStorylinesStream, DiagramItemType.Storyline, this.storylines);
    this.subscriptions['newPlotElement'] = this.subscribe(this.diagramDataService.addedPlotElementsStream, DiagramItemType.PlotElement, this.plotElements);
    this.subscriptions['newRelationship'] = this.subscribe(this.diagramDataService.addedRelationshipsStream, DiagramItemType.Relationship, this.relationships);
    this.subscriptions['newStorylineCharacterConnection'] = this.subscribeConnection(this.diagramDataService.addedStorylineCharacterConnectionsStream, DiagramItemType.StorylineCharacterConnection, this.storylineCharacterConnections);
    this.subscriptions['newStorylinePlotElementConnection'] = this.subscribeConnection(this.diagramDataService.addedStorylinePlotElementConnectionsStream, DiagramItemType.StorylinePlotElementConnection, this.storylinePlotElementConnections);
    this.subscriptions['newCharacterPlotElementConnection'] = this.subscribeConnection(this.diagramDataService.addedCharacterPlotElementConnectionsStream, DiagramItemType.CharacterPlotElementConnection, this.characterPlotElementConnections);
  }

  public reset() {
    for (let key in this.subscriptions) {
      this.subscriptions[key].unsubscribe();
    }

    this.characters = {};
    this.plotElements = {};
    this.storylines = {};
    this.relationships = {};
    this.storylineCharacterConnections = {};
    this.storylinePlotElementConnections = {};
    this.characterPlotElementConnections = {};
  }

  ngOnDestroy(): void {
    this.reset();
  }
}
