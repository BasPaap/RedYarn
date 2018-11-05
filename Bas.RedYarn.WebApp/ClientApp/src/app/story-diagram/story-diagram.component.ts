import { Component, OnInit, Inject, OnDestroy, ViewChild } from '@angular/core';
import { DataSet } from 'vis';
import { DiagramService } from '../diagram.service';
import { VisNetworkGeneratorService } from '../vis-network-generator.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Diagram } from '../diagram-types';
import { Subscription, Observable } from 'rxjs';
import { VisNetworkDirective } from '../vis-network.directive';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit, OnDestroy {
    
  diagram: Diagram;
  networkData = {};

  subscriptions: { [name: string]: Subscription; } = {};

  _visNetwork: VisNetworkDirective;

  @ViewChild(VisNetworkDirective)
  set visNetwork(directive: VisNetworkDirective) {
    this._visNetwork = directive;
  }
  get visNetwork(): VisNetworkDirective {
    return this._visNetwork;    
  }

  onDragEnd(event: any): void {
    console.log("test");
    
  }

  constructor(private route: ActivatedRoute,
    private router: Router,
    private diagramService: DiagramService,
    private visNetworkGeneratorService: VisNetworkGeneratorService) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false; // Force Angular to reload even if only the parameters change.    
  }

  ngOnInit() {
  }

  ngAfterContentInit() {
    this.networkData["nodes"] = new DataSet();
    this.networkData["edges"] = new DataSet();

    const id = this.route.snapshot.paramMap.get('id');
    this.diagramService.getDiagram(id).subscribe((diagram: Diagram) => {
      this.diagram = diagram;
      this.visNetworkGeneratorService.generate(diagram, this.networkData["nodes"], this.networkData["edges"]);
    }, error => console.error(error));

    this.subscriptions['character'] = this.getSubscription(this.diagramService.charactersService(), this.visNetworkGeneratorService.getCharacterNode);
    this.subscriptions['storyline']= this.getSubscription(this.diagramService.storylinesService(), this.visNetworkGeneratorService.getStorylineNode);
    this.subscriptions['plotElement'] = this.getSubscription(this.diagramService.plotElementsService(), this.visNetworkGeneratorService.getPlotElementNode);
  }

  private getSubscription<T>(service: Observable<T>, getNode: (item: T) => any): Subscription {
    return service.subscribe(item => {
      let newNode = getNode(item);
      let nodeId = this.networkData["nodes"].add(newNode);
      this.visNetwork.focusOnNode(nodeId);
    });
  }

  ngOnDestroy(): void {
    for (let key in this.subscriptions) {
      this.subscriptions[key].unsubscribe();
    }  
  }
}
