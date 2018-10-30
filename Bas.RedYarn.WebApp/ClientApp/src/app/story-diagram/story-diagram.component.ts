import { Component, OnInit, Inject } from '@angular/core';
import { DataSet } from 'vis';
import { DiagramService } from '../diagram.service';
import { VisNetworkGeneratorService } from '../vis-network-generator.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Diagram } from '../diagram-types';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit {

  diagram: Diagram;
  graphData = {};

  constructor(private route: ActivatedRoute,
    private router: Router,
    private diagramService: DiagramService,
    private visNetworkGeneratorService: VisNetworkGeneratorService) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false; // Force Angular to reload even if only the parameters change.
  }

  ngOnInit() {
  }

  ngAfterContentInit() {
    this.graphData["nodes"] = new DataSet();
    this.graphData["edges"] = new DataSet();

    const id = this.route.snapshot.paramMap.get('id');
    this.diagramService.getDiagram(id).subscribe((diagram: Diagram) => {
      this.diagram = diagram;
      this.visNetworkGeneratorService.generate(diagram, this.graphData["nodes"], this.graphData["edges"]);
    }, error => console.error(error));
  }
}
