import { Injectable } from '@angular/core';
import { Diagram, Character, Relationship, Storyline, StorylineCharacterConnection, StorylineEssentialPlotElementConnection, EssentialPlotElement, EssentialPlotElementConnection } from './diagram-types';
import { DataSet } from 'vis';

@Injectable({
  providedIn: 'root'
})
export class DiagramGeneratorService {

  constructor() { }

  generate(diagram: Diagram, nodes: DataSet<{}>, edges: DataSet<{}>) {
    nodes.add(diagram.characters.map(c => this.getCharacterNode(c)));
    nodes.add(diagram.storylines.map(s => this.getStorylineNode(s)));
    nodes.add(diagram.essentialPlotElements.map(e => this.getEssentialPlotElementNode(e)));

    edges.add(diagram.relationships.map(r => this.getRelationshipEdge(r)));
    edges.add(diagram.storylineCharacterConnections.map(s => this.getStorylineCharacterConnectionEdge(s)));
    edges.add(diagram.storylineEssentialPlotElementConnections.map(s => this.getStorylineEssentialPlotElementConnectionEdge(s)));
    edges.add(diagram.characterEssentialPlotElementConnections.map(c => this.getCharacterEssentialPlotElementConnectionEdge(c)));
  }

  private getCharacterEssentialPlotElementConnectionEdge(essentialPlotElementConnection: EssentialPlotElementConnection) {
    return {
      from: essentialPlotElementConnection.essentialPlotElementId,
      to: essentialPlotElementConnection.characterId,
      smooth: false,
      dashes: true,
      arrowStrikethrough: false,
      arrows: essentialPlotElementConnection.characterOwnsPlotElement ? 'from' : 'to',      
      color: essentialPlotElementConnection.characterOwnsPlotElement ? { color: 'rgba(0,250,0,1)', highlight: 'rgba(0,250,0,1)' } :
                                                                       { color: 'rgba(253,106,2,1)', highlight: 'rgba(253,106,2,1)' }
    };
  }

  private getEssentialPlotElementNode(essentialPlotElement: EssentialPlotElement) {
    return {
      id: essentialPlotElement.id,
      label: essentialPlotElement.name,
      shape: 'box',
      color: {
        border: 'rgba(50,50,50,0.8)',
        background: 'rgba(200,200,200,1)',
        highlight: { border: 'rgba(50,50,50,1)', background: 'rgba(200,200,200,1)' }
      }
    };
  }

  private getCharacterNode(character: Character) {
    return {
      id: character.id,
      label: character.name,
      shape: 'circularImage',
      image: '404.jpg',
      brokenImage: '../../../assets/default-character.png',
      borderWidth: 2,
      color: { border: 'rgba(0,0,0,0.8)', highlight: { border: 'rgba(0,0,0,1)' } }
    };
  }

  private getRelationshipEdge(relationship: Relationship) {
    return {
      arrows: relationship.isDirectional ? 'to' : undefined,
      from: relationship.fromCharacterId,
      to: relationship.toCharacterId,
      label: relationship.name,
      smooth: {
        type: "continuous",
        forceDirection: "none"
      },
      color: { color: 'rgba(255,0,0,1)', highlight: 'rgba(255,0,0,1)' },
    };
  }

  private getStorylineNode(storyline: Storyline) {
    return {
      id: storyline.id,
      label: storyline.name,
      shape: 'box',
      color: {
        border: 'rgba(0,0,0,0.8)',
        background: 'rgba(255,255,255,1)',
        highlight: { border: 'rgba(0,0,0,1)', background: 'rgba(255,255,255,1)' }
      }
    };
  }

  private getStorylineCharacterConnectionEdge(connection: StorylineCharacterConnection) {
    return {
      from: connection.connectionId,
      to: connection.storylineId,
      smooth: false,
      color: { color: 'rgba(0,0,0,1)', highlight: 'rgba(0,0,0,1)' },
    };
  }

  private getStorylineEssentialPlotElementConnectionEdge(connection: StorylineEssentialPlotElementConnection) {
    return {
      from: connection.connectionId,
      to: connection.storylineId,
      smooth: false,
      arrows: 'to',
      arrowStrikethrough: false,
      color: { color: 'rgba(0,0,0,0.5)', highlight: 'rgba(0,0,0,0.5)' },
    };
  }
}
