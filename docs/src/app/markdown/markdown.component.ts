import { Component, ElementRef, OnInit, OnDestroy } from '@angular/core';
import { Location } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';

import 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';

import { MarkdownService } from './markdown.service';

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
  providers: [MarkdownService],
  templateUrl: './markdown.component.html',
  styleUrls: ['./markdown.component.css']
})
export class MarkdownComponent implements OnInit, OnDestroy {
  md = '## Markdown Works! ##';
  private mdPath: string;
  private sub: any;

  constructor(
    private el: ElementRef, private route: ActivatedRoute, 
    private http: Http, private location: Location,
    private service: MarkdownService) { 
      
      this.el = el;
  }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.mdPath = params['file'];
      
      console.log('MarkdownComponent >> OnInit >> MD Path: ', this.mdPath);

      this.service.getRelativeContent(this.mdPath).then(resp => {
        this.md = resp.text();
        this.el.nativeElement.innerHTML = marked(this.md);
        Prism.highlightAll(false);
      })
      .catch(this.handleError);
    });
  }

  ngOnDestroy(){
    this.sub.unsubscribe();
  }

  /**
   * catch http error
   */
  private handleError(error: any): Promise<any> {
        console.error('An error occurred', error); // for demo purposes only
        return Promise.reject(error.message || error);
  }
}
