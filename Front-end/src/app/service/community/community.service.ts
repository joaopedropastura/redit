import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewCommunity } from './new-community';
import { UserId } from '../user/userId';
import { CommunityPage } from './community-page';

@Injectable({
  providedIn: 'root'
})
export class CommunityService {

  constructor(private http : HttpClient) { }

  add( newCommunity : NewCommunity ){
    return this.http.post<CreateCommunityResult>("http://localhost:5027/forum/new-forum", newCommunity)
  }

  verifyUser(community : CommunityPage){
    return this.http.post<VerifyUser>("http://localhost:5027/forum/verify-user", community)
  }

  subscription(community : CommunityPage){
    return this.http.post<SubsctiptionResult>("http://localhost:5027/forum/add-user", community)
  }
  
}

interface VerifyUser {
  inCommunity : boolean,
  members : string
}

interface CreateCommunityResult {
  message : string
}

interface SubsctiptionResult{
  message : string
}