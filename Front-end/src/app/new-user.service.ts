import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewUser } from './new-user';

@Injectable({
  providedIn: 'root'
})
export class NewUserService {

  constructor(private http: HttpClient) { }
  
  add(NewUser: NewUser){
    return this.http.post("http://localhost:5027/new-user", NewUser)
  }
}
