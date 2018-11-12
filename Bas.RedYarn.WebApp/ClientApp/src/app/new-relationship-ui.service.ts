import { Injectable } from '@angular/core';
import { UserInputService } from './user-input.service';
import { DiagramService } from './diagram.service';
import { Node } from './diagram-types';

@Injectable({
  providedIn: 'root'
})
export class NewRelationshipUIService {

  constructor(private userInputService: UserInputService, private diagramService: DiagramService) {
    this.userInputService.mouseStateStream.subscribe(mouseState => {
    });

    this.diagramService.addedCharactersStream.subscribe(character => this.addNode(character));
    this.diagramService.addedStorylinesStream.subscribe(storyline => this.addNode(storyline));
    this.diagramService.addedPlotElementsStream.subscribe(plotElement => this.addNode(plotElement));

    this.diagramService.updatedCharactersStream.subscribe(character => this.updateNode(character));
    this.diagramService.updatedStorylinesStream.subscribe(storyline => this.updateNode(storyline));
    this.diagramService.updatedPlotElementsStream.subscribe(plotElement => this.updateNode(plotElement));
  }

  private addNode(node: Node) {
    // add [node.id]: node.positionx, node.positiony to nodepositions.
  }

  private updateNode(node: Node) {
    // replace [node.id]: node.positionx, node.positiony in nodepositions.
  }

  public loadNodePositions(nodePositions: { [nodeId: string]: vis.Position }) {

  }
}
