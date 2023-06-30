import { Component } from '@angular/core';
import { NewPost } from '../service/post/new-post';
import { PostService } from '../service/post/post.service';
import { AsyncPipe, CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatAutocompleteModule } from '@angular/material/autocomplete';

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

  constructor (private service : PostService) { }

  newPost()
  {
    this.service.add(this.PostRegister)
    .subscribe(res => {
      console.log(res.message)
    })
  }
}
