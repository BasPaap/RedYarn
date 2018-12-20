import { Component, OnInit } from '@angular/core';
import { DiagramDataService } from 'src/app/services/diagram-data.service';

@Component({
  selector: 'app-my-diagrams',
  templateUrl: './my-diagrams.component.html',
  styleUrls: ['./my-diagrams.component.scss']
})
export class MyDiagramsComponent implements OnInit {

  constructor(private diagramDataService: DiagramDataService) { }

  ngOnInit() {
    
  }

}
