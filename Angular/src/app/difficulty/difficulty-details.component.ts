import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContentService } from '../content.service';
import { Difficulty } from '../difficulty';
import { DifficultyService } from '../difficulty.service';
import { HeroService } from '../hero.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-difficulty-details',
  templateUrl: './difficulty-details.component.html',
  styleUrls: ['./difficulty-details.component.css']
})
export class DifficultyDetailsComponent implements OnInit {
  difficulty: Difficulty = new Difficulty();
  isNew : boolean= true;

  constructor(    private route: ActivatedRoute,
                  private difficultyService: DifficultyService,
                  private location: Location) { }

  ngOnInit(): void {
    var id = this.route.snapshot.paramMap.get('id');
    if(id != null) {
     this.isNew = false;
      this.getDifficulty();
    }
  }

  getDifficulty(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.difficultyService.get(id)
      .subscribe(item => this.difficulty = item);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.difficulty) {
      if ( this.isNew){
        this.difficultyService.addItem(this.difficulty)
          .subscribe(() => this.goBack());
      }else {
        this.difficultyService.updateItem(this.difficulty)
          .subscribe(() => this.goBack());
      }
    }
  }


}
