import { Content } from "./content";

export class Hero {
  public id : number;
  public name : string;
  public contentId : string;
  public image : string;
  public content : Content;

  constructor() {
    this.id = -1;
    this.name = "";
    this.contentId = "";
    this.image = "";
    this.content = new Content();
  }
}
