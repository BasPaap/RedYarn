import { Component, OnInit } from '@angular/core';
import { DiagramDataService } from 'src/app/services/diagram-data.service';
import { Diagram } from 'src/app/diagram-types';

@Component({
  selector: 'app-my-diagrams',
  templateUrl: './my-diagrams.component.html',
  styleUrls: ['./my-diagrams.component.scss']
})
export class MyDiagramsComponent implements OnInit {

  public diagrams: Diagram[];

  constructor(private diagramDataService: DiagramDataService) { }

  ngOnInit() {
    this.diagramDataService.getDiagrams().subscribe(result => this.diagrams = result);
  }
}
