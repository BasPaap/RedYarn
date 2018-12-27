import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin, Observable, Subscription } from 'rxjs';
import { DeleteItemUiService } from 'src/app/services/delete-item-ui.service';
import { UserInteractionService } from 'src/app/services/user-interaction.service';
import { DataSet } from 'vis-redyarn';
import { Character, CharacterPlotElementConnection, Connection, Diagram, PlotElement, Relationship, Storyline } from '../../diagram-types';
import { DiagramDataService } from '../../services/diagram-data.service';
import { DiagramInfoService } from '../../services/diagram-info.service';
import { NetworkItemsConstructorService } from '../../services/network-items-constructor.service';
import { NewConnectionUIService } from '../../services/new-connection-ui.service';
import { NodeLayoutInfoService } from '../../services/node-layout-info.service';
import { VisNetworkDirective } from '../../vis-network.directive';
import { MatDialog } from '@angular/material';
import { CharacterDialogComponent } from '../character-dialog/character-dialog.component';
import { StorylineDialogComponent } from '../storyline-dialog/storyline-dialog.component';
import { PlotElementDialogComponent } from '../plot-element-dialog/plot-element-dialog.component';

@Component({
  selector: 'app-story-diagram',
  templateUrl: './story-diagram.component.html',
  styleUrls: ['./story-diagram.component.scss']
})
export class StoryDiagramComponent implements OnInit, OnDestroy {
  private subscriptions: { [name: string]: Subscription; } = {};
  private dragOffsets: { [id: string]: vis.Position; } = {};
  private _visNetwork: VisNetworkDirective;
  private isLoaded: boolean;

  public networkData = {};
  public diagram: Diagram; // Used to display Diagram.name in the template.

  constructor(private route: ActivatedRoute,
    private deleteItemUiService: DeleteItemUiService,
    private router: Router,
    private interactionService: UserInteractionService,
    private diagramDataService: DiagramDataService,
    private networkItemsConstructorService: NetworkItemsConstructorService,
    private nodeLayoutInfoService: NodeLayoutInfoService,
    private diagramInfoService: DiagramInfoService,
    private dialog: MatDialog,
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
      this.dragOffsets[draggedNode.id] = { x: 0, y: 0 };

      
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

  public onDragStart(eventArgs: any): void {
    for (let nodeId of eventArgs.nodes) {
      if (this.networkData["nodes"].get(nodeId) && eventArgs.pointer.canvas) {
        this.dragOffsets[nodeId] = {
          x: this.networkData["nodes"].get(nodeId).x.valueOf() - eventArgs.pointer.canvas.x.valueOf(),
          y: this.networkData["nodes"].get(nodeId).y.valueOf() - eventArgs.pointer.canvas.y.valueOf()
        };
      }
    }
  }

  public onDragging(eventArgs: any): void {
    for (let nodeId of eventArgs.nodes) {
      let node = this.networkData["nodes"].get(nodeId);
      if (node) {
        this.nodeLayoutInfoService.onUpdatedNode(node,
          this.visNetwork.getBoundingBox(node),
          eventArgs.pointer.canvas.x.valueOf() + this.dragOffsets[nodeId].x,
          eventArgs.pointer.canvas.y.valueOf() + this.dragOffsets[nodeId].y);
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
    this.subscriptions['newStorylineCharacterConnection'] = this.subscribeToNewConnectionStream(this.diagramDataService.addedStorylineCharacterConnectionsStream, this.networkItemsConstructorService.getStorylineCharacterConnectionEdge.bind(this.networkItemsConstructorService));
    this.subscriptions['newStorylinePlotElementConnection'] = this.subscribeToNewConnectionStream(this.diagramDataService.addedStorylinePlotElementConnectionsStream, this.networkItemsConstructorService.getStorylinePlotElementConnectionEdge.bind(this.networkItemsConstructorService));
    this.subscriptions['newCharacterPlotElementConnection'] = this.subscribeToNewConnectionStream(this.diagramDataService.addedCharacterPlotElementConnectionsStream, this.networkItemsConstructorService.getCharacterPlotElementConnectionEdge.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedCharacter'] = this.subscribeToUpdatedNodeStream(this.diagramDataService.updatedCharactersStream, this.networkItemsConstructorService.getCharacterNode.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedStoryline'] = this.subscribeToUpdatedNodeStream(this.diagramDataService.updatedStorylinesStream, this.networkItemsConstructorService.getStorylineNode.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedPlotElement'] = this.subscribeToUpdatedNodeStream(this.diagramDataService.updatedPlotElementsStream, this.networkItemsConstructorService.getPlotElementNode.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedRelationship'] = this.subscribeToUpdatedConnectionStream(this.diagramDataService.updatedRelationshipsStream, this.networkItemsConstructorService.getRelationshipEdge.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedStorylineCharacterConnection'] = this.subscribeToUpdatedConnectionStream(this.diagramDataService.updatedStorylineCharacterConnectionsStream, this.networkItemsConstructorService.getStorylineCharacterConnectionEdge.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedStorylinePlotElementConnection'] = this.subscribeToUpdatedConnectionStream(this.diagramDataService.updatedStorylinePlotElementConnectionsStream, this.networkItemsConstructorService.getStorylinePlotElementConnectionEdge.bind(this.networkItemsConstructorService));
    this.subscriptions['updatedCharacterPlotElementConnection'] = this.subscribeToUpdatedConnectionStream(this.diagramDataService.updatedCharacterPlotElementConnectionsStream, this.networkItemsConstructorService.getCharacterPlotElementConnectionEdge.bind(this.networkItemsConstructorService));

    this.subscriptions['deletedCharacter'] = this.subscribeToDeletedNodeStream(this.diagramDataService.deletedCharactersStream);
    this.subscriptions['deletedStoryline'] = this.subscribeToDeletedNodeStream(this.diagramDataService.deletedStorylinesStream);
    this.subscriptions['deletedPlotElement'] = this.subscribeToDeletedNodeStream(this.diagramDataService.deletedPlotElementsStream);
    this.subscriptions['deletedRelationship'] = this.subscribeToDeletedRelationshipStream(this.diagramDataService.deletedRelationshipsStream);
    this.subscriptions['deletedStorylineCharacterConnection'] = this.subscribeToDeletedConnectionStream(this.diagramDataService.deletedStorylineCharacterConnectionsStream);
    this.subscriptions['deletedStorylinePlotElementConnection'] = this.subscribeToDeletedConnectionStream(this.diagramDataService.deletedStorylinePlotElementConnectionsStream);
    this.subscriptions['deletedCharacterPlotElementConnection'] = this.subscribeToDeletedConnectionStream(this.diagramDataService.deletedCharacterPlotElementConnectionsStream);

    this.diagramInfoService.initialize();

    const id = this.route.snapshot.paramMap.get('id');
    forkJoin([
      this.diagramDataService.getDiagram(id)
    ]).subscribe(values => {
      this.diagram = values[0];
      this.isLoaded = true;
    }, error => console.error(error));

    this.interactionService.keyUpStream.subscribe(keyState => {
      if (keyState.key == "Delete") {
        for (let selectedEdgeId of this.visNetwork.getSelectedEdgeIds()) {
          this.deleteItemUiService.deleteEdge(this.networkData["edges"].get(selectedEdgeId.toString()));
        }

        for (let selectedNodeId of this.visNetwork.getSelectedNodeIds()) {
          this.deleteItemUiService.deleteNode(this.networkData["nodes"].get(selectedNodeId.toString()));
        }
      }

      if (keyState.altKey && keyState.key == "c") {
        this.dialog.open(CharacterDialogComponent);
      }

      if (keyState.altKey && keyState.key == "s") {
        this.dialog.open(StorylineDialogComponent);
      }

      if (keyState.altKey && keyState.key == "p") {
        this.dialog.open(PlotElementDialogComponent);
      }
    });
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
      this.networkData["edges"].update(updatedEdge);
    });
  }

  private subscribeToDeletedRelationshipStream(service: Observable<Relationship>): Subscription {
    return service.subscribe(item => {
      this.networkData["edges"].remove(item.id);
    });
  }

  private subscribeToDeletedConnectionStream<T extends Connection | CharacterPlotElementConnection>(service: Observable<T>): Subscription {
    return service.subscribe(item => {
      
      this.networkData["edges"].remove(`${item.fromNodeId}-${item.toNodeId}`);
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
      this.networkData["nodes"].update(updatedNode);

      this.nodeLayoutInfoService.onUpdatedNode(updatedNode, this.visNetwork.getBoundingBox(updatedNode));
    });
  }

  private subscribeToDeletedNodeStream<T extends Character | Storyline | PlotElement | Relationship>(service: Observable<T>): Subscription {
    return service.subscribe(item => {
      this.networkData["nodes"].remove(item.id);
    });
  }

  ngOnDestroy(): void {
    for (let key in this.subscriptions) {
      this.subscriptions[key].unsubscribe();
    }

    this.diagramInfoService.reset();
  }
}
