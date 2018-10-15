import { Component, OnInit, Inject } from '@angular/core';
import { DataSet } from 'vis';
import { HttpClient } from '@angular/common/http';
import { Diagram } from '../diagram-types';
import { DiagramService } from '../diagram.service';
import { DiagramGeneratorService } from '../diagram-generator.service';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit {

  graphData = {};

  constructor(private diagramService: DiagramService, private diagramGeneratorService: DiagramGeneratorService) {    
  }

  ngOnInit() {
  }

  ngAfterContentInit() {
    this.graphData["nodes"] = new DataSet();
    this.graphData["edges"] = new DataSet();

    this.diagramService.getDiagram('CA275778-7781-46CE-A9AB-323BF0BF7B55').subscribe(diagram => {
      this.diagramGeneratorService.generate(diagram, this.graphData["nodes"], this.graphData["edges"]);      
    }, error => console.error(error));
  }
}
