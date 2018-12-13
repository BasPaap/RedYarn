export enum DiagramItemType {
  Unknown,
  Character,
  Storyline,
  PlotElement,
  Relationship,
  StorylineCharacterConnection,
  StorylinePlotElementConnection,
  CharacterPlotElementConnection
}

export interface Node {
  id: string;
  xPosition: number;
  yPosition: number;
}

export interface Connection {
  fromNodeId: string;
  toNodeId: string;
}

export interface Alias {
  name: string;
}

export interface Character extends Node {
  name: string;
  description?: any;
  aliases: Alias[];
}

export interface Storyline extends Node {
  name: string;
  description: string;
}

export interface PlotElement extends Node {
  name: string;
  description: string;
}

export interface Relationship extends Connection {
  isDirectional: boolean;
  id: string;
  name: string;
}

export interface CharacterPlotElementConnection extends Connection {
  characterOwnsPlotElement: boolean;
}


export interface Diagram {
  id: string;
  name: string;
  characters: Character[];
  storylines: Storyline[];
  plotElements: PlotElement[];
  relationships: Relationship[];
  aliases: Alias[];
  storylineCharacterConnections: Connection[];
  storylinePlotElementConnections: Connection[];
  characterPlotElementConnections: CharacterPlotElementConnection[];
}
