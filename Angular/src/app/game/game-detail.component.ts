import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Game } from '../game';
import { GameService } from '../game.service';
import { ContentService } from '../content.service';
import { Content } from '../content';
import { Hero } from '../hero';
import { Aspect } from '../aspect';
import { Scenario } from '../scenario';
import { Difficulty } from '../difficulty';
import { HeroService } from '../hero.service';
import { AspectService } from '../aspect.service';
import { ScenarioService } from '../scenario.service';
import { DifficultyService } from '../difficulty.service';

@Component({
  selector: 'app-game-detail',
  templateUrl: './game-detail.component.html',
  styleUrls: [ './game-detail.component.css' ]
})
export class GameDetailComponent implements OnInit {
  game: Game = new Game();
  isNew : boolean= true;
  heroes: Hero[] = [];
  aspects: Aspect[] = [];
  scenarios: Scenario[] = [];
  difficulties: Difficulty[] = [];

  constructor(
    private route: ActivatedRoute,
    private gameService: GameService,
    private location: Location,
    private heroService: HeroService,
    private aspectService: AspectService,
    private scenarioService: ScenarioService,
    private difficultyService: DifficultyService
  ) {}

  ngOnInit(): void {
    var id = this.route.snapshot.paramMap.get('id');
    this.getHeroes();
    this.getAspects();
    this.getScenarios();
    this.getDifficulties();
    if(id != null) {
      this.isNew = false;
      this.getGame();
    }
  }

  getGame(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.gameService.get(id)
      .subscribe(game => this.game = game);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.game) {if ( this.isNew){
      this.gameService.addItem(this.game)
        .subscribe(() => this.goBack());
    }else {
      this.gameService.updateItem(this.game)
        .subscribe(() => this.goBack());
    }}
  }
  getHeroes(): void{
    this.heroService.getHeroes()
      .subscribe(heroes => this.heroes = heroes);
  }
  getAspects(): void{
    this.aspectService.getAspects()
      .subscribe(aspects => this.aspects = aspects);
  }
  getScenarios(): void{
    this.scenarioService.getScenarios()
      .subscribe(scenarios => this.scenarios = scenarios);
  }
  getDifficulties(): void{
    this.difficultyService.getAll()
      .subscribe(difficulties => this.difficulties = difficulties);
  }
}
