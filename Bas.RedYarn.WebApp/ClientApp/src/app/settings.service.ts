import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Settings {
  isInDebugMode: boolean,
  UI: {
    newNodePlacementRadius: number, // Radius of the circle around the diagram's origin into which new nodes will be randomly placed, to avoid nodes being placed on top of each other.
    newRelationship: {
      activationZoneWidth: number, // Defines the width of the area around the node in which the cursor activates the new relationship arrow.
      arrow: {
        style: string,
        lineWidth: number
      }
    }
  }
}

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string) { }

  public load(): Observable<Settings> {
    return this.httpClient.get<Settings>(this.apiUrl + 'settings');
  }
}
