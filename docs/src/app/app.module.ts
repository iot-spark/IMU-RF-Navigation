import {HashLocationStrategy, Location, LocationStrategy} from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import 'hammerjs';
import { MaterialModule } from '@angular/material';

import { routes } from './app.routes';

import { MarkdownModule } from 'angular2-markdown';
import { AppComponent } from './app.component';
import { MarkdownComponent } from './markdown/markdown.component';
import { HomeComponent } from './home/home.component';

@NgModule({
  declarations: [
    AppComponent,
    MarkdownComponent,
    HomeComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    MaterialModule.forRoot(),
    MarkdownModule,
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [Location, {provide: LocationStrategy, useClass: HashLocationStrategy}],
  bootstrap: [AppComponent]
})
export class AppModule { }
