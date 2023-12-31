import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { BrowserModule } from '@angular/platform-browser';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import {MatTabsModule} from '@angular/material/tabs';
import {MatMenuModule} from '@angular/material/menu';
import { NgFor, AsyncPipe } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginPageComponent } from './login-page/login-page.component';
import { NavComponent } from './nav/nav.component';
import { FeedPageComponent } from './feed-page/feed-page.component';
import { PasswordComponent } from './password/password.component';
import { NewAccountPageComponent } from './new-account-page/new-account-page.component';
import { InitPageComponent } from './init-page/init-page.component';
import { HttpClientModule } from '@angular/common/http';
import { MainComponent } from './main/main.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { NewCommunityComponent } from './new-community/new-community.component';
import { NewPostComponent } from './new-post/new-post.component';
import { SearchCommunityComponent } from './search-community/search-community.component';
import { PostComponent } from './post/post.component';
import { CommunityPageComponent } from './community-page/community-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    PasswordComponent,
    InitPageComponent,
    ProfilePageComponent,
    CommunityPageComponent,
    MainComponent,
  ],
  imports: [
    SearchCommunityComponent,
    MatProgressSpinnerModule,
    NewAccountPageComponent,
    BrowserAnimationsModule,
    NewCommunityComponent,
    MatSlideToggleModule,
    MatFormFieldModule,
    LoginPageComponent,
    FeedPageComponent,
    HttpClientModule,
    NewPostComponent,
    AppRoutingModule,
    MatButtonModule,
    MatInputModule,
    MatTabsModule,
    PostComponent,
    BrowserModule,
    MatIconModule,
    MatMenuModule,
    FormsModule,
    AsyncPipe,
    NgFor,
    

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
