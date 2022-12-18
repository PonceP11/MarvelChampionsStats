import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Aspect } from '../aspect';
import { AspectService } from '../aspect.service';

@Component({
  selector: 'app-aspect-detail',
  templateUrl: './aspect-detail.component.html',
  styleUrls: [ './aspect-detail.component.css' ]
})
export class AspectDetailComponent implements OnInit {
  aspect: Aspect | undefined;

  constructor(
    private route: ActivatedRoute,
    private aspectService: AspectService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getAspect();
  }

  getAspect(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.aspectService.getAspect(id)
      .subscribe(aspect => this.aspect = aspect);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.aspect) {
      this.aspectService.updateAspect(this.aspect)
        .subscribe(() => this.goBack());
    }
  }
}
