import { Component, Input, OnInit } from '@angular/core';
import { MdSidenav, MdButton } from '@angular/material'

import { FileService } from './file.service';

require('../theme.scss');

@Component({
  selector: 'app-root',
  providers: [FileService],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  private posts: any;
  @Input() title: string;
  
  constructor(private fileService: FileService) { 
    this.title = 'app works!';
  }

  ngOnInit(){
    this.fileService.getRelativeContent('/assets/posts.json').then(resp => {
        var postsJson = resp.text();
        this.posts = JSON.parse(postsJson);
        console.log('AppComponent >> posts received: ', this.posts);
      })
      .catch(this.handleError);
  }

  handleError(error: any): Promise<any>{
    console.error('AppComponent >> An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }
}
