import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CommunityList } from './community/communityList';
import { UserId } from './user/userId';
import { PostCard } from './post/post-card';

@Injectable({
  providedIn: 'root'
})
export class FeedPageService {

  constructor(private http : HttpClient) { }

  communityList ( userId : UserId){

    console.log(userId)
    return this.http.post<CommunityList[]>("http://localhost:5027/post/list-communities", userId)  
  }

  postsLists ( userId : UserId){
    return this.http.post<PostCard[]>("http://localhost:5027/post/list-posts", userId)
  }
}


