export interface Node {
  id: string;
  xPosition: number;
  yPosition: number;
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

export interface Relationship {
  fromCharacterId: string;
  toCharacterId: string;
  name: string;
  isDirectional: boolean;
}

export interface StorylineCharacterConnection {
  connectionId: string;
  storylineId: string;
}

export interface StorylinePlotElementConnection {
  connectionId: string;
  storylineId: string;
}

export interface Diagram {
  id: string;
  name: string;
  characters: Character[];
  storylines: Storyline[];
  plotElements: PlotElement[];
  relationships: Relationship[];
  aliases: Alias[];
  storylineCharacterConnections: StorylineCharacterConnection[];
  storylinePlotElementConnections: StorylinePlotElementConnection[];
  characterPlotElementConnections: PlotElementConnection[];
  characterAliasConnections: AliasConnection[];
}

export interface AliasConnection {
  aliasId: string;
  characterId: string;
}

export interface PlotElementConnection {
  plotElementId: string;
  characterId: string;
  characterOwnsPlotElement: boolean;
}
