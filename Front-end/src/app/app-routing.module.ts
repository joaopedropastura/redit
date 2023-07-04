import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginPageComponent } from './login-page/login-page.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { NewAccountPageComponent } from './new-account-page/new-account-page.component';
import { InitPageComponent } from './init-page/init-page.component';
import { MainComponent } from './main/main.component';
import { NewCommunityComponent } from './new-community/new-community.component';
import { NewPostComponent } from './new-post/new-post.component';
import { CommunityPageComponent } from './community-page/community-page.component';

const routes: Routes = [
  {
    path: '', component : MainComponent,
    children: [
      { path : 'feed', component : FeedPageComponent}
    ]
  },
  { path: "login", component: LoginPageComponent },
  { path: "initial", component: InitPageComponent },
  { path: "new-account", component : NewAccountPageComponent },
  { path: "new-community", component : NewCommunityComponent },
  { path: "new-post", component : NewPostComponent },
  { path: "community-page/:communtyName", component : CommunityPageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }
