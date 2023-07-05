import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewCommunity } from './new-community';

@Injectable({
  providedIn: 'root'
})
export class CommunityService {

  constructor(private http : HttpClient) { }

  add( newCommunity : NewCommunity ){
    return this.http.post<CreateCommunityResult>("http://localhost:5027/forum/new-forum", newCommunity)
  }

  verifyUser(){
    // return this.http.post<>
  }
  
}

interface CreateCommunityResult {
  message : string
}