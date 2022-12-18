import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { MatTabsModule } from '@angular/material';
import { HeroDetailComponent } from './hero/hero-detail.component';
import { HeroSearchComponent } from './hero-search/hero-search.component';
import { HeroComponent } from './hero/hero.component';
import { MessagesComponent } from './messages/messages.component';
import { AspectComponent } from './aspect/aspect.component';

import { AppRoutingModule } from './app-routing.module';
import { AspectDetailComponent } from './aspect/aspect-detail.component';
import { AspectNewComponent } from './aspect/aspect-new.component';
import { ContentComponent } from './content/content.component';
import { ContentNewComponent } from './content/content-new.component';
import { ContentDetailComponent } from './content/content-detail.component';
import { HeroNewComponent } from './hero/hero-new.component';
import { DifficultyComponent } from './difficulty/difficulty.component';
import { MatDialogModule } from '@angular/material/dialog';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DifficultyDetailsComponent } from './difficulty/difficulty-details.component';
import { ScenarioComponent } from './scenario/scenario.component';
import { ScenarioDetailComponent } from './scenario/scenario-detail.component';
import { GameComponent } from './game/game.component';
import { GameDetailComponent } from './game/game-detail.component'
@NgModule({
  declarations: [
    AppComponent,
    HeroDetailComponent,
    HeroSearchComponent,
    HeroComponent,
    MessagesComponent,
    AspectComponent,
    AspectDetailComponent,
    AspectNewComponent,
    ContentComponent,
    ContentNewComponent,
    ContentDetailComponent,
    HeroNewComponent,
    DifficultyComponent,
    DifficultyDetailsComponent,
    ScenarioComponent,
    ScenarioDetailComponent,
    GameComponent,
    GameDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    MatTabsModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
