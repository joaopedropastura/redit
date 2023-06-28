import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NewUser } from './new-user';
import { LoginUserResult } from './login-user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  
  add(NewUser: NewUser){
    return this.http.post<CreateUserResult>("http://localhost:5027/user/new-user", NewUser)
  }

  login(LoginUserResult : LoginUserResult){
      return this.http.post<LoginResult>("http://localhost:5027/user/login", LoginUserResult)
  }
}

interface CreateUserResult {
  message: string
}

interface LoginResult {
  jwt : string
}