import { Injectable } from '@angular/core';
import { Character, PlotElement, Relationship, Storyline } from '../diagram-types';
import { SettingsService } from './settings.service';

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

  public getRelationshipConnection(relationship: Relationship) {
    return {
      arrows: relationship.isDirectional ? 'to' : undefined,
      from: relationship.fromNodeId,
      to: relationship.toNodeId,
      label: relationship.name,
      smooth: {
        type: "continuous",
        forceDirection: "none"
      },
      color: { color: 'rgba(255,0,0,1)', highlight: 'rgba(255,0,0,1)' },
    };
  }

  public getStorylineNode(storyline: Storyline) {
    return {
      id: storyline.id,
      label: storyline.name,
      shape: this.settingsService.settings.ui.storylineNode.shape,
      color: {
        border: this.settingsService.settings.ui.storylineNode.borderColor,
        background: this.settingsService.settings.ui.storylineNode.background,
        highlight: { border: this.settingsService.settings.ui.storylineNode.highlightBorderColor, background: this.settingsService.settings.ui.storylineNode.background },
        hover: { border: this.settingsService.settings.ui.storylineNode.borderColor, background: this.settingsService.settings.ui.storylineNode.background }
      },
      borderWidth: this.settingsService.settings.ui.storylineNode.borderWidth,
      labelHighlightBold: false,
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
      color: {
        border: this.settingsService.settings.ui.plotElementNode.borderColor,
        background: this.settingsService.settings.ui.plotElementNode.background,
        highlight: { border: this.settingsService.settings.ui.plotElementNode.highlightBorderColor, background: this.settingsService.settings.ui.plotElementNode.background },
        hover: { border: this.settingsService.settings.ui.plotElementNode.borderColor, background: this.settingsService.settings.ui.plotElementNode.background }
      },
      borderWidth: this.settingsService.settings.ui.plotElementNode.borderWidth,
      labelHighlightBold: false,
      x: plotElement.xPosition,
      y: plotElement.yPosition,
      plotElement: plotElement
    };
  }

  public getCharacterNode(character: Character) {
    return {
      id: character.id,
      label: character.name,
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
      labelHighlightBold: false,
      x: character.xPosition,
      y: character.yPosition,
      character: character
    };
  }

  //public generate(diagram: Diagram, nodes: DataSet<{}>, edges: DataSet<{}>) {
  //  nodes.add(diagram.characters.map(c => this.getCharacterNode(c)));
  //  nodes.add(diagram.storylines.map(s => this.getStorylineNode(s)));
  //  nodes.add(diagram.plotElements.map(e => this.getPlotElementNode(e)));

  //  edges.add(diagram.relationships.map(r => this.getRelationshipEdge(r)));
  //  edges.add(diagram.storylineCharacterConnections.map(s => this.getStorylineCharacterConnectionEdge(s)));
  //  edges.add(diagram.storylinePlotElementConnections.map(s => this.getStorylinePlotElementConnectionEdge(s)));
  //  edges.add(diagram.characterPlotElementConnections.map(c => this.getCharacterPlotElementConnectionEdge(c)));
  //}

  //private getCharacterPlotElementConnectionEdge(plotElementConnection: PlotElementConnection) {
  //  return {
  //    from: plotElementConnection.plotElementId,
  //    to: plotElementConnection.characterId,
  //    smooth: false,
  //    dashes: true,
  //    arrowStrikethrough: false,
  //    arrows: plotElementConnection.characterOwnsPlotElement ? 'from' : 'to',      
  //    color: plotElementConnection.characterOwnsPlotElement ? { color: 'rgba(0,250,0,1)', highlight: 'rgba(0,250,0,1)' } :
  //                                                                     { color: 'rgba(253,106,2,1)', highlight: 'rgba(253,106,2,1)' }
  //  };
  //}
  //private getRelationshipEdge(relationship: Relationship) {
  //  return {
  //    arrows: relationship.isDirectional ? 'to' : undefined,
  //    from: relationship.fromCharacterId,
  //    to: relationship.toCharacterId,
  //    label: relationship.name,
  //    smooth: {
  //      type: "continuous",
  //      forceDirection: "none"
  //    },
  //    color: { color: 'rgba(255,0,0,1)', highlight: 'rgba(255,0,0,1)' },
  //  };
  //}

  //private getStorylineCharacterConnectionEdge(connection: StorylineCharacterConnection) {
  //  return {
  //    from: connection.connectionId,
  //    to: connection.storylineId,
  //    smooth: false,
  //    color: { color: 'rgba(0,0,0,1)', highlight: 'rgba(0,0,0,1)' },
  //  };
  //}

  //private getStorylinePlotElementConnectionEdge(connection: StorylinePlotElementConnection) {
  //  return {
  //    from: connection.connectionId,
  //    to: connection.storylineId,
  //    smooth: false,
  //    arrows: 'to',
  //    arrowStrikethrough: false,
  //    color: { color: 'rgba(0,0,0,0.5)', highlight: 'rgba(0,0,0,0.5)' },
  //  };
  //}
}
