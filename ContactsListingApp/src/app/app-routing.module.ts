import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { ContactListComponent } from './contacts/contact-list.component';
import { ServerErrorComponent } from './errorpages/server-error/server-error.component';
import { NotFoundComponent } from './errorpages/not-found/not-found.component';

const routes: Routes = [
  {path: 'ServerError', component: ServerErrorComponent},
  {path: 'NotFound', component: NotFoundComponent},
  {path: '**', component: ContactListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
