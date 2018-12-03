import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class Settings {
  isInDebugMode: boolean = false;
  ui: {
    storylineNode: {
      shape: "box",
      borderColor: "rgba(0,0,0,0)",
      background: "rgba(255,255,255,1)",
      highlightBorderColor: "rgba(0,0,0,1)",
      borderWidth: 1
    },
    plotElementNode: {
      shape: "box",
      borderColor: "rgba(50,50,50,1)",
      background: "rgba(200,200,200,1)",
      highlightBorderColor: "rgba(50,50,50,1)",
      borderWidth: 1
    },
    characterNode: {
      shape: "circularImage",
      radius: 25,
      borderColor: "rgba(0,0,0,1)",
      highlightBorderColor: "rgba(0,0,0,1)",
      borderWidth: 2,
      brokenImageUri: "../../../assets/default-character.png"
    },
    newNodePlacementRadius: 5; // Radius of the circle around the diagram's origin into which new nodes will be randomly placed, to avoid nodes being placed on top of each other.
    newRelationship: {
      activationZoneWidth: 5; // Defines the width of the area around the node in which the cursor activates the new relationship arrow.
      nodeHighlightFactor: 1;
      arrow: {
        style: "#000000",
        lineWidth: 1,
        headLength: 10
      }
    }
  }
}

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  public settings: Settings = new Settings();

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string) { }

  public load() {
    this.httpClient.get<Settings>(this.apiUrl + 'settings').subscribe(loadedSettings => this.settings = loadedSettings);
  }
}
