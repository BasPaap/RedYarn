import { Injectable } from '@angular/core';
import { Character, PlotElement, Relationship, Storyline, CharacterPlotElementConnection, Connection } from '../diagram-types';
import { SettingsService } from './settings.service';

// Constructs vis network objects to visualize RedYarn characters, relationships, plots etc.
@Injectable({
  providedIn: 'root'
})
export class NetworkItemsConstructorService {

  constructor(private settingsService: SettingsService) { }

  public getStartingCoordinate(): number {
    return this.getRandomNumber(0, this.settingsService.settings.ui.newNodePlacementRadius);
  }

  private getRandomNumber(min: number, max: number): number {
    return Math.floor(Math.random() * (max - min + 1) + min);
  }

  private getDeepCopy<T>(object: T): T {
    return JSON.parse(JSON.stringify(object));
  }

  public getStorylineNode(storyline: Storyline) {
    let plotElementNode = this.getDeepCopy(this.settingsService.settings.ui.storylineNode);
    plotElementNode["id"] = storyline.id;
    plotElementNode["label"] = storyline.name;
    plotElementNode["x"] = storyline.xPosition;
    plotElementNode["y"] = storyline.yPosition;
    plotElementNode["storyline"] = storyline;

    return plotElementNode;
  }

  public getPlotElementNode(plotElement: PlotElement) {
    let plotElementNode = this.getDeepCopy(this.settingsService.settings.ui.plotElementNode);
    plotElementNode["id"] = plotElement.id;
    plotElementNode["label"] = plotElement.name;
    plotElementNode["x"] = plotElement.xPosition;
    plotElementNode["y"] = plotElement.yPosition;
    plotElementNode["plotElement"] = plotElement;

    return plotElementNode;
  }

  public getCharacterNode(character: Character) {
    let characterNode = this.getDeepCopy(this.settingsService.settings.ui.characterNode);
    characterNode["id"] = character.id;
    characterNode["label"] = character.name;
    characterNode["x"] = character.xPosition;
    characterNode["y"] = character.yPosition;
    characterNode["character"] = character;
    characterNode["image"] = '../../../assets/default-character.png';
    return characterNode;
  }

  public getRelationshipEdge(relationship: Relationship) {
    let relationshipEdge = this.getDeepCopy(this.settingsService.settings.ui.relationshipEdge);
    relationshipEdge["arrows"] = relationship.isDirectional ? 'to' : undefined;
    relationshipEdge["from"] = relationship.fromNodeId;
    relationshipEdge["to"] = relationship.toNodeId;
    relationshipEdge["label"] = relationship.name;

    return relationshipEdge;
  }

  public getCharacterPlotElementConnectionEdge(plotElementConnection: CharacterPlotElementConnection) {
    let characterPlotElementConnectionEdge = this.getDeepCopy(this.settingsService.settings.ui.characterPlotElementConnectionEdge);
    characterPlotElementConnectionEdge["color"] = plotElementConnection.characterOwnsPlotElement ? { color: this.settingsService.settings.ui.characterOwnsPlotElementEdgeColor, highlight: this.settingsService.settings.ui.characterOwnsPlotElementEdgeColor, hover: this.settingsService.settings.ui.characterOwnsPlotElementEdgeColor } :
      { color: this.settingsService.settings.ui.characterDoesNotOwnPlotElementEdgeColor, highlight: this.settingsService.settings.ui.characterDoesNotOwnPlotElementEdgeColor, hover: this.settingsService.settings.ui.characterDoesNotOwnPlotElementEdgeColor };
    characterPlotElementConnectionEdge["arrows"] = plotElementConnection.characterOwnsPlotElement ? 'from' : 'to';
    characterPlotElementConnectionEdge["from"] = plotElementConnection.fromNodeId;
    characterPlotElementConnectionEdge["to"] = plotElementConnection.toNodeId;

    return characterPlotElementConnectionEdge;
  }

  public getStorylineCharacterConnectionEdge(connection: Connection) {
    let storylineCharacterConnectionEdge = this.getDeepCopy(this.settingsService.settings.ui.storylineCharacterConnectionEdge);
    storylineCharacterConnectionEdge["from"] = connection.fromNodeId;
    storylineCharacterConnectionEdge["to"] = connection.toNodeId;

    return storylineCharacterConnectionEdge;    
  }

  public getStorylinePlotElementConnectionEdge(connection: Connection) {
    let storylinePlotElementConnectionEdge = this.getDeepCopy(this.settingsService.settings.ui.storylinePlotElementConnectionEdge);
    storylinePlotElementConnectionEdge["from"] = connection.fromNodeId;
    storylinePlotElementConnectionEdge["to"] = connection.toNodeId;
    
    return storylinePlotElementConnectionEdge;    
  }
}
