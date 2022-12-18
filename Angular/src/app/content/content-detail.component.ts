import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Content } from '../content';
import { ContentService } from '../content.service';

@Component({
  selector: 'app-content-detail',
  templateUrl: './content-detail.component.html',
  styleUrls: [ './content-detail.component.css' ]
})
export class ContentDetailComponent implements OnInit {
  content: Content | undefined;

  constructor(
    private route: ActivatedRoute,
    private contentService: ContentService,
    private location: Location
  ) {}

  ngOnInit(): void {
    this.getContent();
  }

  getContent(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!, 10);
    this.contentService.getContent(id)
      .subscribe(content => this.content = content);
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.content) {
      this.contentService.updateContent(this.content)
        .subscribe(() => this.goBack());
    }
  }
}

