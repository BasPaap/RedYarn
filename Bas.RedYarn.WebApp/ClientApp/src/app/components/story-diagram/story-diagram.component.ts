import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, Observable, Subscription } from 'rxjs';
import { DataSet } from 'vis-redyarn';
import { Diagram } from '../../diagram-types';
import { DiagramDataService } from '../../services/diagram-data.service';
import { NodeLayoutInfoService } from '../../services/node-layout-info.service';
import { NewConnectionUIService } from '../../services/new-connection-ui.service';
import { SettingsService } from '../../services/settings.service';
import { NetworkItemsConstructorService } from '../../services/network-items-constructor.service';
import { VisNetworkDirective } from '../../vis-network.directive';
import { DiagramInfoService } from '../../services/diagram-info.service';

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
    private diagramDataService: DiagramDataService,
    private settingsService: SettingsService,
    private networkItemsConstructorService: NetworkItemsConstructorService,
    private nodeLayoutInfoService: NodeLayoutInfoService,
    private diagramInfoService: DiagramInfoService,
    private newRelationshipUI: NewConnectionUIService) {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false; // Force Angular to reload even if only the parameters change.    
  }

  @ViewChild(VisNetworkDirective)
  public set visNetwork(directive: VisNetworkDirective) {
    this._visNetwork = directive;
    this.newRelationshipUI.network = directive;
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
        this.diagramDataService.updateStoryline(draggedNode.storyline).subscribe();
      } else if (draggedNode.plotElement) {
        draggedNode.plotElement.xPosition = position.x;
        draggedNode.plotElement.yPosition = position.y;
        this.diagramDataService.updatePlotElement(draggedNode.plotElement).subscribe();
      } else if (draggedNode.character) {
        draggedNode.character.xPosition = position.x;
        draggedNode.character.yPosition = position.y;
        this.diagramDataService.updateCharacter(draggedNode.character).subscribe();
      }
    }
  }  

  ngOnInit() {
  }

  ngAfterContentInit() {
    this.networkData["nodes"] = new DataSet<vis.Node>();
    this.networkData["edges"] = new DataSet<vis.Edge>();
    
    this.subscriptions['newCharacter'] = this.subscribeToNewNodeStream(this.diagramDataService.addedCharactersStream, this.networkItemsConstructorService.getCharacterNode.bind(this.networkItemsConstructorService));
    this.subscriptions['newStoryline'] = this.subscribeToNewNodeStream(this.diagramDataService.addedStorylinesStream, this.networkItemsConstructorService.getStorylineNode.bind(this.networkItemsConstructorService));
    this.subscriptions['newPlotElement'] = this.subscribeToNewNodeStream(this.diagramDataService.addedPlotElementsStream, this.networkItemsConstructorService.getPlotElementNode.bind(this.networkItemsConstructorService));
    this.subscriptions['newRelationship'] = this.subscribeToNewConnectionStream(this.diagramDataService.addedRelationshipsStream, this.networkItemsConstructorService.getRelationshipEdge.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedCharacter'] = this.subscribeToUpdatedNodeStream(this.diagramDataService.updatedCharactersStream, this.networkItemsConstructorService.getCharacterNode.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedStoryline'] = this.subscribeToUpdatedNodeStream(this.diagramDataService.updatedStorylinesStream, this.networkItemsConstructorService.getStorylineNode.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedPlotElement'] = this.subscribeToUpdatedNodeStream(this.diagramDataService.updatedPlotElementsStream, this.networkItemsConstructorService.getPlotElementNode.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedRelationship'] = this.subscribeToUpdatedConnectionStream(this.diagramDataService.updatedRelationshipsStream, this.networkItemsConstructorService.getRelationshipEdge.bind(this.networkItemsConstructorService));

    this.diagramInfoService.initialize();

    const id = this.route.snapshot.paramMap.get('id');
    forkJoin([
      this.diagramDataService.getDiagram(id)
    ]).subscribe(values => {
      this.diagram = values[0];
      //this.networkItemsConstructorService.generate(this.diagram, this.networkData["nodes"], this.networkData["edges"]);
      //this.newRelationshipUI.loadNodePositions(this.visNetwork.getNodePositions());
      this.isLoaded = true;
    }, error => console.error(error));

  }

  private subscribeToNewConnectionStream<T>(service: Observable<T>, getEdge: (item: T) => any): Subscription {
    return service.subscribe(item => {
      let newEdge = getEdge(item);
      this.networkData["edges"].add(newEdge);
    });
  }

  private subscribeToUpdatedConnectionStream<T>(service: Observable<T>, getEdge: (item: T) => any): Subscription {
    return service.subscribe(item => {
      let updatedEdge = getEdge(item);
      this.networkData["edges"][updatedEdge.id] = updatedEdge;
    });
  }


  private subscribeToNewNodeStream<T>(service: Observable<T>, getNode: (item: T) => any): Subscription {
    return service.subscribe(item => {
      let newNode = getNode(item);
      let nodeId = this.networkData["nodes"].add(newNode);
      this.nodeLayoutInfoService.onUpdatedNode(newNode, this.visNetwork.getBoundingBox(newNode));

      if (this.isLoaded) {
        this.visNetwork.focusOnNode(nodeId);
      }
    });    
  }

  private subscribeToUpdatedNodeStream<T>(service: Observable<T>, getNode: (item: T) => any): Subscription {
    return service.subscribe(item => {
      let updatedNode = getNode(item);
      this.networkData["nodes"][updatedNode.id] = updatedNode;

      this.nodeLayoutInfoService.onUpdatedNode(updatedNode, this.visNetwork.getBoundingBox(updatedNode));
    });
  }

  ngOnDestroy(): void {
    for (let key in this.subscriptions) {
      this.subscriptions[key].unsubscribe();
    }

    this.diagramInfoService.reset();
  }
}
