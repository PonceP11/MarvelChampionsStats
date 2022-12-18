import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Hero } from '../hero';
import { HeroService } from '../hero.service';
import { Content } from '../content';
import { ContentService } from '../content.service';


@Component({
  selector: 'app-hero-new',
  templateUrl: './hero-new.component.html',
  styleUrls: ['./hero-new.component.css']
})
export class HeroNewComponent implements OnInit {
  contents: Content[] =[];
  hero: Hero = new Hero();

  constructor(
    private route: ActivatedRoute,
    private heroService: HeroService,
    private contentService: ContentService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getContents();
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.hero) {
      this.heroService.addHero(this.hero)
        .subscribe(() => this.goBack());
    }
  }

  getContents(): void{
    this.contentService.getContents()
      .subscribe(contents => this.contents = contents);
  }

}
