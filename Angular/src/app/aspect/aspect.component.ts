import { Component, OnInit } from '@angular/core';
import { Aspect } from '../aspect';
import { AspectService } from '../aspect.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-aspect',
  templateUrl: './aspect.component.html',
  styleUrls: [ './aspect.component.css' ]
})
export class AspectComponent implements OnInit {
  aspects: Aspect[] = [];

  constructor(private aspectService: AspectService,
              private location: Location) { }

  ngOnInit(): void {
    this.getAspects();
  }

  getAspects(): void {
    this.aspectService.getAspects()
      .subscribe(aspects => this.aspects = aspects);
  }
  onDelete(id: number): void{
    this.aspectService.deleteAspect(id).subscribe(() => window.location.reload());
  }
}
