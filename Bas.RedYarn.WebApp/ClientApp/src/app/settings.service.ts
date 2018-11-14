import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Settings {
  isInDebugMode: boolean,
  ui: {
    circularImageSize: number,
    newNodePlacementRadius: number, // Radius of the circle around the diagram's origin into which new nodes will be randomly placed, to avoid nodes being placed on top of each other.
    newRelationship: {
      activationZoneWidth: number, // Defines the width of the area around the node in which the cursor activates the new relationship arrow.
      arrow: {
        style: string,
        lineWidth: number,
        headLength: number
      }
    }
  }
}

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  public settings: Settings = {
    isInDebugMode: false,
    ui: {
      circularImageSize: 25,
      newNodePlacementRadius: 5,
      newRelationship: {
        activationZoneWidth: 5,
        arrow: {
          style: "#000000",
          lineWidth: 1,
          headLength: 10
        }
      }
    }
  };

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string) { }

  public load() {
    this.httpClient.get<Settings>(this.apiUrl + 'settings').subscribe(loadedSettings => this.settings = loadedSettings);
  }
}
