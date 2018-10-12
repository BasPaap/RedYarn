import { Injectable } from '@angular/core';
import { Diagram } from './diagram-types';
import { DataSet } from 'vis';

@Injectable({
  providedIn: 'root'
})
export class DiagramGeneratorService {

  constructor() { }

  generate(diagram: Diagram, nodes: DataSet<{}>, edges: DataSet<{}>) {
    for (let character of diagram.characters) {
      nodes.add({ id: character.id, label: character.name, shape: 'circle' });
    }

    for (let relationship of diagram.relationships) {
      edges.add({
        arrows: relationship.isDirectional ? 'to' : undefined,
        from: relationship.fromCharacterId,
        to: relationship.toCharacterId,
        label: relationship.name,
        smooth: {
          type: "continuous",
          forceDirection: "none"
        },
        color: { color: 'rgba(255,0,0,1)', highlight: 'rgba(255,0,0,1)' },
      });
    }

    for (let storyline of diagram.storylines) {
      nodes.add({ id: storyline.id, label: storyline.name, shape: 'box' });
    }

    for (let connection of diagram.storylineCharacterConnections) {
      edges.add({
        from: connection.connectionId,
        to: connection.storylineId,
        smooth: false,
        color: { color: 'rgba(0,0,0,1)', highlight: 'rgba(0,0,0,1)' },
      });
    }
  }
}
