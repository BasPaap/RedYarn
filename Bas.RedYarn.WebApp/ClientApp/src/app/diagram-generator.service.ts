import { Injectable } from '@angular/core';
import { Diagram, Character, Relationship, Storyline, StorylineCharacterConnection, StorylineEssentialPlotElementConnection, EssentialPlotElement, EssentialPlotElementConnection } from './diagram-types';
import { DataSet } from 'vis';

@Injectable({
  providedIn: 'root'
})
export class DiagramGeneratorService {

  constructor() { }

  generate(diagram: Diagram, nodes: DataSet<{}>, edges: DataSet<{}>) {
    for (let character of diagram.characters) {
      nodes.add(this.getCharacterNode(character));
    }

    for (let relationship of diagram.relationships) {
      edges.add(this.getRelationshipEdge(relationship));
    }

    for (let storyline of diagram.storylines) {
      nodes.add(this.getStorylineNode(storyline));
    }

    for (let connection of diagram.storylineCharacterConnections) {
      edges.add(this.getStorylineCharacterConnectionEdge(connection));
    }

    for (let essentialPlotElement of diagram.essentialPlotElements) {
      nodes.add(this.getEssentialPlotElementNode(essentialPlotElement));
    }

    for (let connection of diagram.storylineEssentialPlotElementConnections) {
      edges.add(this.getStorylineEssentialPlotElementConnectionEdge(connection));
    }

    for (let essentialPlotElementConnection of diagram.characterEssentialPlotElementConnections) {
      edges.add(this.getCharacterEssentialPlotElementConnectionEdge(essentialPlotElementConnection))
    }
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
