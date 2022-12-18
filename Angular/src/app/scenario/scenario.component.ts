import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Scenario } from '../scenario';
import { ScenarioService } from '../scenario.service';

@Component({
  selector: 'app-scenario',
  templateUrl: './scenario.component.html',
  styleUrls: ['./scenario.component.css']
})
export class ScenarioComponent implements OnInit {
  scenarios : Scenario[] = [];
  constructor(public scenarioService: ScenarioService) { }

  ngOnInit(): void {
    this.getItems();
  }

  getItems(){
    this.scenarioService.getScenarios().subscribe(items => this.scenarios = items);

  }

  onDelete(id: number): void{
    this.scenarioService.deleteScenario(id).subscribe(() => window.location.reload());
  }

}
