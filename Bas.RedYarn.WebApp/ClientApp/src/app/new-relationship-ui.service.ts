import { Injectable } from '@angular/core';
import { UserInputService } from './user-input.service';
import { Node } from './diagram-types';
import { NetworkItemsService, NodeLayout } from './network-items.service';

@Injectable({
  providedIn: 'root'
})
export class NewRelationshipUIService {

  private nodeLayouts: NodeLayout[] = [];

  constructor(private userInputService: UserInputService, private networkItemsService: NetworkItemsService) {
    this.userInputService.mouseStateStream.subscribe(mouseState => {
      // find closest node
    });

    this.networkItemsService.nodeLayoutsStream.subscribe(nodeLayout => this.nodeLayouts.push(nodeLayout));    
  }  
}
