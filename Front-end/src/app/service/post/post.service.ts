import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewPost } from './new-post';

@Injectable({
  providedIn: 'root'
})
export class PostService {

  constructor(private http : HttpClient) { }

  add ( newPost : NewPost ){
    return this.http.post<CreatePostResult>("http://localhost:5027/post/new-post", newPost)
  }

}

interface CreatePostResult {
  message : string
}