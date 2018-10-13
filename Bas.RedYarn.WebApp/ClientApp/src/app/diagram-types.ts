export interface Character {
  id: string;
  name: string;
  description?: any;
  aliases: string[];
}

export interface Storyline {
  id: string;
  name: string;
  description: string;
}

export interface PlotElement {
  id: string;
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
  name: string;
  characters: Character[];
  storylines: Storyline[];
  plotElements: PlotElement[];
  relationships: Relationship[];
  storylineCharacterConnections: StorylineCharacterConnection[];
  storylinePlotElementConnections: StorylinePlotElementConnection[];
  characterPlotElementConnections: PlotElementConnection[];
}


export interface PlotElementConnection {
  plotElementId: string;
  characterId: string;
  characterOwnsPlotElement: boolean;
}
