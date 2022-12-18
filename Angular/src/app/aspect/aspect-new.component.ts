import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Aspect } from '../aspect';
import { AspectService } from '../aspect.service';


@Component({
  selector: 'app-aspect-new',
  templateUrl: './aspect-new.component.html',
  styleUrls: ['./aspect-new.component.css']
})
export class AspectNewComponent implements OnInit {

  aspect: Aspect = {
    id: 0,
    name: '',
    color: '',
    image: '',
    icon: ''
  };

  constructor(
    private route: ActivatedRoute,
    private aspectService: AspectService,
    private location: Location
  ) {}

  // @ts-ignore
  ngOnInit(): void {
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.aspect) {
      this.aspectService.addAspect(this.aspect)
        .subscribe(() => this.goBack());
    }
  }

}
