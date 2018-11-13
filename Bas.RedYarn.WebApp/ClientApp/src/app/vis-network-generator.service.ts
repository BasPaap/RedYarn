import { Injectable } from '@angular/core';
import { Character, Storyline, StorylineCharacterConnection, StorylinePlotElementConnection, PlotElement, PlotElementConnection } from './diagram-types';
import { SettingsService } from './settings.service';

@Injectable({
  providedIn: 'root'
})
export class VisNetworkGeneratorService {

  constructor(private settingsService: SettingsService) { }
    
  public getStorylineNode(storyline: Storyline) {
    return {
      id: storyline.id,
      label: storyline.name,
      shape: 'box',
      color: {
        border: 'rgba(0,0,0,0.8)',
        background: 'rgba(255,255,255,1)',
        highlight: { border: 'rgba(0,0,0,1)', background: 'rgba(255,255,255,1)' }
      },
      x: storyline.xPosition,
      y: storyline.yPosition,
      storyline: storyline
    };
  }

  public getPlotElementNode(plotElement: PlotElement) {
    return {
      id: plotElement.id,
      label: plotElement.name,
      shape: 'box',
      color: {
        border: 'rgba(50,50,50,0.8)',
        background: 'rgba(200,200,200,1)',
        highlight: { border: 'rgba(50,50,50,1)', background: 'rgba(200,200,200,1)' }
      },
      x: plotElement.xPosition,
      y: plotElement.yPosition,
      plotElement: plotElement
    };
  }

  public getCharacterNode(character: Character) {
    return {
      id: character.id,
      label: character.name,
      shape: 'circularImage',
      size: this.settingsService.settings.ui.circularImageSize,
      image: '../../../assets/default-character.png',
      brokenImage: '../../../assets/default-character.png',
      borderWidth: 2,
      color: { border: 'rgba(0,0,0,0.8)', highlight: { border: 'rgba(0,0,0,1)' } },
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
