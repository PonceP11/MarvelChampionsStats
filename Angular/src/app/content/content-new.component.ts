import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { Content } from '../content';
import { ContentService } from '../content.service';


@Component({
  selector: 'app-content-new',
  templateUrl: './content-new.component.html',
  styleUrls: ['./content-new.component.css']
})
export class ContentNewComponent implements OnInit {

  content: Content = {
    id: 0,
    name: '',
    type: '',
    image: '',
    icon: '',
    wave: ''
  };

  constructor(
    private route: ActivatedRoute,
    private contentService: ContentService,
    private location: Location
  ) {}

  // @ts-ignore
  ngOnInit(): void {
  }

  goBack(): void {
    this.location.back();
  }

  save(): void {
    if (this.content) {
      this.contentService.addContent(this.content)
        .subscribe(() => this.goBack());
    }
  }

}
