import { RouterModule, Routes } from '@angular/router';

import { MarkdownComponent } from './markdown/markdown.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'md', component: MarkdownComponent },
  // { path: '',
  //   redirectTo: '/heroes',
  //   pathMatch: 'full'
  // },
  //{ path: '**', component: PageNotFoundComponent }
];