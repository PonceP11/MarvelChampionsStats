import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContentService } from '../content.service';
import { Scenario } from '../scenario';
import { ScenarioService } from '../scenario.service';
import { HeroService } from '../hero.service';
import { Location } from '@angular/common';

import { Content } from '../content';

@Component({
  selector: 'app-scenario-detail',
  templateUrl: './scenario-detail.component.html',
  styleUrls: ['./scenario-detail.component.css']
})
export class ScenarioDetailComponent implements OnInit {
  scenario: Scenario = new Scenario();
  isNew : boolean= true;
  contents: Content[] = []

  constructor(    private route: ActivatedRoute,
                  private scenarioService: ScenarioService,
                  private location: Location,
                  private contentService: ContentService
  ) { }

  ngOnInit(): void {
    var id = this.route.snapshot.paramMap.get('id');
    this.getContents();
    if(id != null) {
      this.isNew = false;
      this.getScenario();
    }
  }
  
  getContents(): void{
    this.contentService.getContents()
      .subscribe(contents => this.contents = contents);
  }

  getScenario(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.scenarioService.getScenario(id)
      .subscribe(item => this.scenario = item);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.scenario) {
      if ( this.isNew){
        this.scenarioService.addScenario(this.scenario)
          .subscribe(() => this.goBack());
      }else {
        this.scenarioService.updateScenario(this.scenario)
          .subscribe(() => this.goBack());
      }
    }
  }


}
