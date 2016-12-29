import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/Rx';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class MarkdownService {

  constructor(private http: Http) { }

  getRelativeContent(relativePath) {
    return this.http.get(window.location.origin + window.location.pathname + relativePath).toPromise();
  }

  getContent(fullPath) {
    return this.http.get(fullPath).toPromise();
  }

}
