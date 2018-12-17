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

  public getStorylineNode(storyline: Storyline) {
    return {
      id: storyline.id,
      chosen: false,
      label: storyline.name,
      shape: this.settingsService.settings.ui.storylineNode.shape,
      margin: this.settingsService.settings.ui.storylineNode.margin,
      font: {
        size: this.settingsService.settings.ui.storylineNode.fontSize
      },
      color: {
        border: this.settingsService.settings.ui.storylineNode.borderColor,
        background: this.settingsService.settings.ui.storylineNode.background,
        highlight: { border: this.settingsService.settings.ui.storylineNode.highlightBorderColor, background: this.settingsService.settings.ui.storylineNode.background },
        hover: { border: this.settingsService.settings.ui.storylineNode.borderColor, background: this.settingsService.settings.ui.storylineNode.background }
      },
      borderWidth: this.settingsService.settings.ui.storylineNode.borderWidth,
      labelHighlightBold: this.settingsService.settings.ui.storylineNode.labelHighlightBold,
      x: storyline.xPosition,
      y: storyline.yPosition,
      storyline: storyline
    };
  }

  public getPlotElementNode(plotElement: PlotElement) {
    return {
      id: plotElement.id,
      label: plotElement.name,
      shape: this.settingsService.settings.ui.plotElementNode.shape,
      font: {
        size: this.settingsService.settings.ui.plotElementNode.fontSize
      },
      margin: this.settingsService.settings.ui.plotElementNode.margin,
      chosen: {
        node: false
      },
      color: {
        border: this.settingsService.settings.ui.plotElementNode.borderColor,
        background: this.settingsService.settings.ui.plotElementNode.background,
        highlight: { border: this.settingsService.settings.ui.plotElementNode.highlightBorderColor, background: this.settingsService.settings.ui.plotElementNode.background },
        hover: { border: this.settingsService.settings.ui.plotElementNode.borderColor, background: this.settingsService.settings.ui.plotElementNode.background }
      },
      borderWidth: this.settingsService.settings.ui.plotElementNode.borderWidth,
      labelHighlightBold: this.settingsService.settings.ui.plotElementNode.labelHighlightBold,
      x: plotElement.xPosition,
      y: plotElement.yPosition,
      plotElement: plotElement
    };
  }

  public getCharacterNode(character: Character) {
    return {
      id: character.id,
      label: character.name,
      chosen: false,
      shape: this.settingsService.settings.ui.characterNode.shape,
      size: this.settingsService.settings.ui.characterNode.radius,
      image: '../../../assets/default-character.png',
      brokenImage: this.settingsService.settings.ui.characterNode.brokenImageUri,
      borderWidth: this.settingsService.settings.ui.characterNode.borderWidth,
      color: {
        border: this.settingsService.settings.ui.characterNode.borderColor,
        highlight: { border: this.settingsService.settings.ui.characterNode.highlightBorderColor },
        hover: { border: this.settingsService.settings.ui.characterNode.borderColor }
      },
      labelHighlightBold: this.settingsService.settings.ui.characterNode.labelHighlightBold,
      x: character.xPosition,
      y: character.yPosition,
      character: character
    };
  }

  public getRelationshipEdge(relationship: Relationship) {
    return {
      arrows: relationship.isDirectional ? 'to' : undefined,
      chosen: false,
      from: relationship.fromNodeId,
      to: relationship.toNodeId,
      label: relationship.name,
      smooth: {
        type: "continuous",
        forceDirection: "none"
      },
      color: { color: this.settingsService.settings.ui.relationshipEdge.color, highlight: this.settingsService.settings.ui.relationshipEdge.highlightColor },
    };
  }

  public getCharacterPlotElementConnectionEdge(plotElementConnection: CharacterPlotElementConnection) {
    return {
      from: plotElementConnection.fromNodeId,
      to: plotElementConnection.toNodeId,
      chosen: false,
      smooth: false,
      dashes: true,
      arrowStrikethrough: false,  
      arrows: plotElementConnection.characterOwnsPlotElement ? 'from' : 'to',      
      color: plotElementConnection.characterOwnsPlotElement ? { color: 'rgba(0,250,0,1)', highlight: 'rgba(0,250,0,1)' } :
                                                                       { color: 'rgba(253,106,2,1)', highlight: 'rgba(253,106,2,1)' }
    };
  }

  public getStorylineCharacterConnectionEdge(connection: Connection) {
    return {
      from: connection.fromNodeId,
      to: connection.toNodeId,
      chosen: false,
      smooth: false,
      color: { color: 'rgba(0,0,0,1)', highlight: 'rgba(0,0,0,1)' },
    };
  }

  public getStorylinePlotElementConnectionEdge(connection: Connection) {
    return {
      from: connection.fromNodeId,
      to: connection.toNodeId,
      chosen: false,
      smooth: false,
      arrows: 'from',
      arrowStrikethrough: false,
      color: { color: 'rgba(0,0,0,0.5)', highlight: 'rgba(0,0,0,0.5)' },
    };
  }
}
