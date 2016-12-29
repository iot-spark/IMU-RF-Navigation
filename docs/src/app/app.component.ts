import { Component, Input } from '@angular/core';
import { MdSidenav, MdButton } from '@angular/material'

require('../theme.scss');

@Component({
  selector: 'app-root',
  providers: [],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @Input() title: string;
  
  constructor() { 
    this.title = 'app works!';
  }

  
}
