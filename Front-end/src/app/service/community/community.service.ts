import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewCommunity } from './new-community';
import { UserId } from '../user/userId';
import { CommunityPage } from './community-page';
import { CommunityData } from './community-data';

@Injectable({
  providedIn: 'root'
})
export class CommunityService {

  constructor(private http : HttpClient) { }

  add( newCommunity : NewCommunity ) {
    return this.http.post<CreateCommunityResult>("http://localhost:5027/forum/new-forum", newCommunity)
  }

  CommunityLoad(community : CommunityPage) {
    return this.http.post<CommunityData>("http://localhost:5027/forum/verify-user", community)
  }

  subscription(community : CommunityPage) {
    return this.http.post<SubsctiptionResult>("http://localhost:5027/forum/add-user", community)
  }
  
}

interface VerifyUser {
  inCommunity : boolean,
  members : string,
  communtyDescription : string,
  communtyTitle : string,
}

interface CreateCommunityResult {
  message : string
}

interface SubsctiptionResult{
  message : string
}