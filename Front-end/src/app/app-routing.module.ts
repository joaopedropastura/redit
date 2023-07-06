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
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { MatTabsModule } from '@angular/material/tabs';
import { SearchCommunityComponent } from './search-community/search-community.component';

const routes: Routes = [
  {
    path: '', component : MainComponent,
    children: [
      { path : 'feed', component : FeedPageComponent},
      { path: "profile-page", component : ProfilePageComponent},
      { path: "new-account", component : NewAccountPageComponent },
      { path: "new-community", component : NewCommunityComponent },
      { path: "community-page/:communtyName", component : CommunityPageComponent },
      { path: "new-post", component : NewPostComponent },
      { path: "search-community", component : SearchCommunityComponent },
    ]
  },
  { path: "login", component: LoginPageComponent },
  { path: "initial", component: InitPageComponent },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [
    RouterModule,
    MatTabsModule
  ],
  
})
export class AppRoutingModule { }
