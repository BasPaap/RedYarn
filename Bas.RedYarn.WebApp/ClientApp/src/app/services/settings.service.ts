import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { NodeOptions, EdgeOptions, Options } from 'vis-redyarn';


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
    networkOptions: Options;
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

// Factory function for the APP_INITIALIZE provider, to ensure that settings are loaded during the initialization.
export function settingsFactory(settingsService: SettingsService) {
  return () => settingsService.load();
}

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  public settings: Settings;

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string) { }

  public load(): Promise<any> {
    // Because this method is called by a factory function for the APP_INITIALIZE provider, we need to return a Promise.
    const promise = this.httpClient.get<Settings>(this.apiUrl + 'settings')
      .toPromise()
      .then(loadedSettings => {
        this.settings = loadedSettings;
        return loadedSettings;
      });
    return promise;
  }
}

