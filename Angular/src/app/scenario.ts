import { Content } from "./content";

export class Scenario {
  public id : number;
  public name : string;
  public contentId : string;
  public image : string;
  public icon : string;
  public content : Content;

  constructor() {
    this.id = -1;
    this.name = "";
    this.contentId = "";
    this.image = "";
    this.icon = "";
    this.content = new Content();
  }
}
