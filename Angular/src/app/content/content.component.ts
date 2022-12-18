import { Component, OnInit } from '@angular/core';
import { Content } from '../content';
import { ContentService } from '../content.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: [ './content.component.css' ]
})
export class ContentComponent implements OnInit {
  contents: Content[] = [];

  constructor(private contentService: ContentService,
              private location: Location) { }

  ngOnInit(): void {
    this.getContents();
  }

  getContents(): void {
    this.contentService.getContents()
      .subscribe(contents => this.contents = contents);
  }
  onDelete(id: number): void{
    this.contentService.deleteContent(id).subscribe(() => window.location.reload());
  }
}
