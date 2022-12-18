import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AspectDetailComponent } from './aspect/aspect-detail.component';
import { AspectNewComponent } from './aspect/aspect-new.component';
import { AspectComponent } from './aspect/aspect.component';
import { HeroComponent } from './hero/hero.component';
import { HeroDetailComponent } from './hero/hero-detail.component'
import { ContentComponent } from './content/content.component';
import { ContentNewComponent } from './content/content-new.component';
import { ContentDetailComponent } from './content/content-detail.component';
import { HeroNewComponent } from './hero/hero-new.component';
import { DifficultyComponent } from './difficulty/difficulty.component';
import { DifficultyDetailsComponent } from './difficulty/difficulty-details.component';
import { ScenarioComponent } from './scenario/scenario.component';
import {ScenarioDetailComponent} from './scenario/scenario-detail.component';
import { GameDetailComponent } from './game/game-detail.component';
import { GameComponent } from './game/game.component';

const routes: Routes = [
  { path: 'heroes', component: HeroComponent },
  { path: 'hero-detail/:id', component: HeroDetailComponent},
  { path: 'hero-add', component: HeroNewComponent},
  { path: 'aspects', component: AspectComponent },
  { path: 'aspect-detail/:id', component: AspectDetailComponent},
  { path: 'aspect-add', component: AspectNewComponent},
  { path: 'contents', component: ContentComponent},
  { path: 'content-detail/:id', component: ContentDetailComponent},
  { path: 'content-add', component: ContentNewComponent},
  { path: 'difficulties', component: DifficultyComponent},
  { path: 'difficulty-detail/:id', component: DifficultyDetailsComponent},
  { path: 'difficulty-add', component: DifficultyDetailsComponent},
  { path: 'scenarios', component: ScenarioComponent},
  { path: 'scenario-detail/:id', component: ScenarioDetailComponent},
  { path: 'scenario-add', component: ScenarioDetailComponent},
  { path: 'games', component: GameComponent},
  { path: 'game-detail/:id', component: GameDetailComponent},
  { path: 'game-add', component: GameDetailComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
