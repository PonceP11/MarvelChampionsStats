import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Hero } from '../hero';
import { HeroService } from '../hero.service';
import { ContentService } from '../content.service';
import { Content } from '../content';

@Component({
  selector: 'app-hero-detail',
  templateUrl: './hero-detail.component.html',
  styleUrls: [ './hero-detail.component.css' ]
})
export class HeroDetailComponent implements OnInit {
  hero: Hero | undefined;
  contents: Content[] = []

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private location: Location,
    private contentService: ContentService
  ) {}

  ngOnInit(): void {
    this.getHero();
    this.getContents();
  }

  getHero(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.heroService.getHero(id)
      .subscribe(hero => this.hero = hero);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.hero) {
      this.heroService.updateHero(this.hero)
        .subscribe(() => this.goBack());
    }
  }
  getContents(): void{
    this.contentService.getContents()
      .subscribe(contents => this.contents = contents);
  }
}
