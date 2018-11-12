import { Injectable } from '@angular/core';
import { UserInputService } from './user-input.service';

@Injectable({
  providedIn: 'root'
})
export class NewRelationshipUIService {
    
  constructor(private userInputService: UserInputService)
  {
    this.userInputService.mouseStateStream.subscribe(mouseState => {

    });
  }

  public loadNodePositions(nodePositions: { [nodeId: string]: vis.Position }) {

  }
}
