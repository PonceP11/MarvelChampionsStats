import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Game } from '../game';
import { GameService } from '../game.service';

@Component({
  selector: 'app-game',
  templateUrl: './game.component.html',
  styleUrls: ['./game.component.css']
})
export class GameComponent implements OnInit {
  games : Game[] = [];
  constructor(public gameService: GameService) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems(){
    this.gameService.getAll().subscribe(items => this.games = items);

  }

  onDelete(id: number): void{
    this.gameService.deleteItem(id).subscribe(() => window.location.reload());
  }

}
