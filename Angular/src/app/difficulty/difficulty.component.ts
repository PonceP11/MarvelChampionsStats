import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Difficulty } from '../difficulty';
import { DifficultyService } from '../difficulty.service';

@Component({
  selector: 'app-difficulty',
  templateUrl: './difficulty.component.html',
  styleUrls: ['./difficulty.component.css']
})
export class DifficultyComponent implements OnInit {
  difficulties : Difficulty[] = [];
  constructor(public difficultyService: DifficultyService) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems(){
    this.difficultyService.getAll().subscribe(items => this.difficulties = items);

  }

  onDelete(id: number): void{
    this.difficultyService.deleteItem(id).subscribe(() => window.location.reload());
  }

}
