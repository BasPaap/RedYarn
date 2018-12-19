import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { NodeOptions, EdgeOptions } from 'vis-redyarn';

export interface Settings {
  isInDebugMode: boolean;
  ui: {
    storylineNode: NodeOptions;
    plotElementNode: NodeOptions;
    characterNode: NodeOptions;
    relationshipEdge: EdgeOptions;
    characterPlotElementConnectionEdge: EdgeOptions;
    storylineCharacterConnectionEdge: EdgeOptions;
    storylinePlotElementConnectionEdge: EdgeOptions;
    characterOwnsPlotElementEdgeColor: string;
    characterDoesNotOwnPlotElementEdgeColor: string;
    newNodePlacementRadius: number; // Radius of the circle around the diagram's origin into which new nodes will be randomly placed, to avoid nodes being placed on top of each other.
    newRelationship: {
      activationZoneWidth: number; // Defines the width of the area around the node in which the cursor activates the new relationship arrow.
      nodeHighlightFactor: number;
      arrow: {
        style: string;
        lineWidth: number;
        headLength: number;
      }
    }
  }
}

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  public settings: Settings;

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string) { }

  public load() {
    this.httpClient.get<Settings>(this.apiUrl + 'settings').subscribe(loadedSettings => this.settings = loadedSettings);
  }
}
