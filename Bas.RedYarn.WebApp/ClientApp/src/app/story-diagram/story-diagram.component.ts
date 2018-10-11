import { Component, OnInit, Inject } from '@angular/core';
import { DataSet } from 'vis';
import { HttpClient } from '@angular/common/http';
import { Diagram } from '../diagram-types';
import { DiagramService } from '../diagram.service';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit {

  graphData = {};
  
  constructor(private diagramService: DiagramService) {    
  }

  ngOnInit() {
  }

  ngAfterContentInit() {
    var nodes = new DataSet();
    var edges = new DataSet();
    
    this.graphData["nodes"] = nodes;
    this.graphData["edges"] = edges;

    this.diagramService.getDiagram(1).subscribe(diagram => {
      
      for (let character of diagram.characters) {
        nodes.add({ id: character.id, label: character.name });
      }
            
      for (let relationship of diagram.relationships) {
        edges.add({ from: relationship.fromCharacterId, to: relationship.toCharacterId, label: relationship.name });
      }
    }, error => console.error(error));
  }
}
