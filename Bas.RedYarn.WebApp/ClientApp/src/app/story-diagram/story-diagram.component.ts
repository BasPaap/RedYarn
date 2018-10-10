import { Component, OnInit, Inject } from '@angular/core';
import { DataSet } from 'vis';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit {

  graphData = {};
  private diagram: Diagram;
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  ngOnInit() {

  }

  ngAfterContentInit() {
    var nodes = new DataSet([]);

    var edges = new DataSet([]);
    
    this.graphData["nodes"] = nodes;
    this.graphData["edges"] = edges;

    this.http.get<Diagram>(this.baseUrl + 'api/diagram/1').subscribe(result => {
      this.diagram = result;

      for (let character of this.diagram.characters) {
        nodes.add({ id: character.id, label: character.name });
      }
            
      for (let relationship of this.diagram.relationships) {
        edges.add({ from: relationship.fromCharacterId, to: relationship.toCharacterId, label: relationship.name });
      }
    }, error => console.error(error));

  }

}


  export interface Character {
    id: string;
    name: string;
    description?: any;
    aliases: string[];
  }

  export interface Relationship {
    fromCharacterId: string;
    toCharacterId: string;
    name: string;
  }

  export interface Diagram {
    name?: any;
    characters: Character[];
    storylines: any[];
    relationships: Relationship[];
    storylineConnections: any[];
  }


