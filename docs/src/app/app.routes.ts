import { RouterModule, Routes } from '@angular/router';

import { MarkdownComponent } from 'app/markdown/markdown.component';
import { HomeComponent } from 'app/home/home.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'md', component: MarkdownComponent },
  // { path: '',
  //   redirectTo: '/heroes',
  //   pathMatch: 'full'
  // },
  //{ path: '**', component: PageNotFoundComponent }
];