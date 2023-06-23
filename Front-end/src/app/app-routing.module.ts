import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { NewAccountPageComponent } from './new-account-page/new-account-page.component';
import { InitPageComponent } from './init-page/init-page.component';

const routes: Routes = [
  { path: "login", component: LoginPageComponent },
  { path: "feed", component: FeedPageComponent },
  { path: "initial", component: InitPageComponent},
  { path: "new-account", component : NewAccountPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }
