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

export interface EssentialPlotElement {
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

export interface StorylineEssentialPlotElementConnection {
  connectionId: string;
  storylineId: string;
}

export interface Diagram {
  name: string;
  characters: Character[];
  storylines: Storyline[];
  essentialPlotElements: EssentialPlotElement[];
  relationships: Relationship[];
  storylineCharacterConnections: StorylineCharacterConnection[];
  storylineEssentialPlotElementConnections: StorylineEssentialPlotElementConnection[];
}
