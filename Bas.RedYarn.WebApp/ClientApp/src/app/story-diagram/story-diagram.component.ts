import { Component, OnInit, Inject, OnDestroy, ViewChild } from '@angular/core';
import { DataSet } from 'vis-redyarn';
import { DiagramService } from '../diagram.service';
import { VisNetworkGeneratorService } from '../vis-network-generator.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Diagram } from '../diagram-types';
import { Subscription, Observable, forkJoin } from 'rxjs';
import { VisNetworkDirective } from '../vis-network.directive';
import { Settings, SettingsService } from '../settings.service';
import { NewRelationshipUIService } from '../new-relationship-ui.service';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit, OnDestroy {
  private subscriptions: { [name: string]: Subscription; } = {};
  private _visNetwork: VisNetworkDirective;
  private isLoaded: boolean;

  public networkData = {};
  public diagram: Diagram; // Used to display Diagram.name in the template.

  constructor(private route: ActivatedRoute,
    private router: Router,
    private diagramService: DiagramService,
    private settingsService: SettingsService,
    private visNetworkGeneratorService: VisNetworkGeneratorService,
    private newRelationshipUI: NewRelationshipUIService) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false; // Force Angular to reload even if only the parameters change.    
  }

  @ViewChild(VisNetworkDirective)
  public set visNetwork(directive: VisNetworkDirective) {
    this._visNetwork = directive;
  }
  public get visNetwork(): VisNetworkDirective {
    return this._visNetwork;
  }
  
  public onDragEnd(event: any): void {
    let draggedNodes = this.networkData["nodes"].get({
      filter: function (item) {
        return (event.nodes.includes(item.id));
      }
    });

    for (let key in draggedNodes) {
      let draggedNode = draggedNodes[key];
      let position = this.visNetwork.getNodePosition(draggedNode.id)[draggedNode.id];
      if (draggedNode.storyline) {
        draggedNode.storyline.xPosition = position.x;
        draggedNode.storyline.yPosition = position.y;
        this.diagramService.updateStoryline(draggedNode.storyline).subscribe();
      } else if (draggedNode.plotElement) {
        draggedNode.plotElement.xPosition = position.x;
        draggedNode.plotElement.yPosition = position.y;
        this.diagramService.updatePlotElement(draggedNode.plotElement).subscribe();
      } else if (draggedNode.character) {
        draggedNode.character.xPosition = position.x;
        draggedNode.character.yPosition = position.y;
        this.diagramService.updateCharacter(draggedNode.character).subscribe();
      }
    }
  }  

  ngOnInit() {
  }

  ngAfterContentInit() {
    this.networkData["nodes"] = new DataSet();
    this.networkData["edges"] = new DataSet();

    const id = this.route.snapshot.paramMap.get('id');
    forkJoin([
      this.diagramService.getDiagram(id)
    ]).subscribe(values => {
      this.diagram = values[0];
      //this.visNetworkGeneratorService.generate(this.diagram, this.networkData["nodes"], this.networkData["edges"]);
      //this.newRelationshipUI.loadNodePositions(this.visNetwork.getNodePositions());
      this.isLoaded = true;
    }, error => console.error(error));

    this.subscriptions['newCharacter'] = this.subscribeToNewNodeStream(this.diagramService.addedCharactersStream, this.visNetworkGeneratorService.getCharacterNode);
    this.subscriptions['newStoryline'] = this.subscribeToNewNodeStream(this.diagramService.addedStorylinesStream, this.visNetworkGeneratorService.getStorylineNode);
    this.subscriptions['newPlotElement'] = this.subscribeToNewNodeStream(this.diagramService.addedPlotElementsStream, this.visNetworkGeneratorService.getPlotElementNode);
    this.subscriptions['updatedCharacter'] = this.subscribeToUpdatedNodeStream(this.diagramService.addedCharactersStream, this.visNetworkGeneratorService.getCharacterNode);
    this.subscriptions['updatedStoryline'] = this.subscribeToUpdatedNodeStream(this.diagramService.addedStorylinesStream, this.visNetworkGeneratorService.getStorylineNode);
    this.subscriptions['updatedPlotElement'] = this.subscribeToUpdatedNodeStream(this.diagramService.addedPlotElementsStream, this.visNetworkGeneratorService.getPlotElementNode);
  }

  private subscribeToNewNodeStream<T>(service: Observable<T>, getNode: (item: T) => any): Subscription {
    return service.subscribe(item => {
      let newNode = getNode(item);
      let nodeId = this.networkData["nodes"].add(newNode);
      if (this.isLoaded) {
        this.visNetwork.focusOnNode(nodeId);
      }
    });    
  }

  private subscribeToUpdatedNodeStream<T>(service: Observable<T>, getNode: (item: T) => any): Subscription {
    return service.subscribe(item => {
      let updatedNode = getNode(item);
      let nodeId = this.networkData["nodes"][updatedNode.id] = updatedNode;      
    });
  }

  ngOnDestroy(): void {
    for (let key in this.subscriptions) {
      this.subscriptions[key].unsubscribe();
    }
  }
}
