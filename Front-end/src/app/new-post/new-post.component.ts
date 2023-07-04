import { Component, ElementRef, ViewChild, inject } from '@angular/core';

import { MatAutocompleteModule, MatAutocompleteSelectedEvent } from '@angular/material/autocomplete';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatChipInputEvent, MatChipsModule} from '@angular/material/chips';
import { MatFormFieldModule } from '@angular/material/form-field';
import { PostService } from '../service/post/post.service';
import { MatButtonModule } from '@angular/material/button';
import { AsyncPipe, CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import {COMMA, ENTER} from '@angular/cdk/keycodes';
import { NewPost } from '../service/post/new-post';
import { Observable } from 'rxjs';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {map, startWith} from 'rxjs/operators';


@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    AsyncPipe,
    MatChipsModule
  ]
})

export class NewPostComponent {
  
  tempJwt = sessionStorage.getItem("UserId") ?? ''
  PostRegister : NewPost = 
  {
    jwt : this.tempJwt,
    idCommunity : 0,
    postData : "",
    title : ""
  }

  
}
