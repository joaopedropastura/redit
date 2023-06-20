import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent {
  email = ""
  link = ""
  password = ""

  constructor(private router: Router) { }

  passwordChanged(event: any) {
    this.password = event
  }

  login(){
    
    if (this.email == "123" && this.password == "123"){
      sessionStorage.setItem('user', 'redit')
      this.router.navigate(["/feed"])
    }
  }
}
