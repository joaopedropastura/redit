import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgFor, AsyncPipe } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';

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
import {MatMenuModule} from '@angular/material/menu';
import { NewPostComponent } from './new-post/new-post.component';


@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    PasswordComponent,
    InitPageComponent,
    MainComponent,
    ProfilePageComponent,
  ],
  imports: [
    NewPostComponent,
    NewCommunityComponent,
    LoginPageComponent,
    NewAccountPageComponent,
    FeedPageComponent,
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatSlideToggleModule,
    MatProgressSpinnerModule,
    MatFormFieldModule,
    MatInputModule,
    NgFor,
    AsyncPipe,
    MatIconModule,
    HttpClientModule,
    MatMenuModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
