import { Component, ElementRef, OnInit } from '@angular/core';

import * as  marked  from 'marked';

import 'prismjs/prism';
import 'prismjs/components/prism-c';
import 'prismjs/components/prism-java';
import 'prismjs/components/prism-cpp';
import 'prismjs/components/prism-python';
import 'prismjs/components/prism-perl';
import 'prismjs/components/prism-php';
import 'prismjs/components/prism-scss';

@Component({
  selector: 'app-markdown',
  providers: [],
  templateUrl: './markdown.component.html',
  styleUrls: ['./markdown.component.css']
})
export class MarkdownComponent implements OnInit {
  md = '## Markdown Works! ##';

  constructor(private el: ElementRef) { 
      this.el = el;
      this.md = '### hello from .ctor! ###';

      let timeoutId = setTimeout(() => {  
        console.log('hello from .ctor');

        this.md = '### hello from .ctor w/ delay! ###';

        clearTimeout(timeoutId);
      }, 100);
  }

  ngOnInit() {
    let timeoutId = setTimeout(() => {  
      console.log('hello from OnInit');

      this.md = '### hello! ###';
      this.el.nativeElement.innerHTML = marked('### hello from OnInit w/ delay! ###');

      clearTimeout(timeoutId);
    }, 2000);


  }

}
