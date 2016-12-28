import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-markdown',
  providers: [],
  templateUrl: './markdown.component.html',
  styleUrls: ['./markdown.component.css']
})
export class MarkdownComponent implements OnInit {
  title = 'Markdown Works!';

  constructor() { }

  ngOnInit() {
  }

}
