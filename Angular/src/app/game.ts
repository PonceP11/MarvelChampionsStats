import { Aspect } from "./aspect";
import { Content } from "./content";
import { Difficulty } from "./difficulty";
import { Hero } from "./hero";
import { Scenario } from "./scenario";

export class Game {
  public id : number;
  public result : boolean;
  public aspectId : number;
  public aspect : Aspect;
  public heroId : number;
  public hero : Hero;
  public difficultyId : number;
  public difficulty : Difficulty;
  public scenarioId : number;
  public scenario : Scenario;
  public schemeEmpty : boolean;
  public secondarySchemeEmpty : boolean;
  public notMinions : boolean;

  constructor() {
    this.id = -1;
    this.result = false;
    this.aspectId = -1;
    this.heroId = -1;
    this.difficultyId = -1;
    this.scenarioId = -1;
    this.schemeEmpty = false;
    this.secondarySchemeEmpty = false;
    this.notMinions = false;
    this.aspect = new Aspect();
    this.scenario = new Scenario();
    this.hero = new Hero();
    this.difficulty = new Difficulty();
  }
}
