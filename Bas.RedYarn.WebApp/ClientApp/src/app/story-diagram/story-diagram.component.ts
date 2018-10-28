import { Component, OnInit, Inject } from '@angular/core';
import { DataSet } from 'vis';
import { DiagramService } from '../diagram.service';
import { VisNetworkGeneratorService } from '../vis-network-generator.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit {

  graphData = {};

  constructor(private route: ActivatedRoute,
              private diagramService: DiagramService,
              private visNetworkGeneratorService: VisNetworkGeneratorService) {    
  }

  ngOnInit() {
  }
    
  ngAfterContentInit() {
    this.graphData["nodes"] = new DataSet();
    this.graphData["edges"] = new DataSet();

    const id = this.route.snapshot.paramMap.get('id');
    this.diagramService.getDiagram(id).subscribe(diagram => {
      this.visNetworkGeneratorService.generate(diagram, this.graphData["nodes"], this.graphData["edges"]);      
    }, error => console.error(error));
  }
}
