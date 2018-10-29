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

export class Diagram {
  id: string = "00000000-0000-0000-0000-000000000000";
  name: string = "";
  characters: Character[] = null;
  storylines: Storyline[] = null;
  plotElements: PlotElement[] = null;
  relationships: Relationship[] = null;
  storylineCharacterConnections: StorylineCharacterConnection[] = null;
  storylinePlotElementConnections: StorylinePlotElementConnection[] = null;
  characterPlotElementConnections: PlotElementConnection[] = null;
}


export interface PlotElementConnection {
  plotElementId: string;
  characterId: string;
  characterOwnsPlotElement: boolean;
}
