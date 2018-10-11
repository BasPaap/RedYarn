export interface Character {
  id: string;
  name: string;
  description: any;
  aliases: string[];
}

export interface Relationship {
  fromCharacterId: string;
  toCharacterId: string;
  name: string;
}

export interface Diagram {
  name: any;
  characters: Character[];
  storylines: any[];
  relationships: Relationship[];
  storylineConnections: any[];
}
