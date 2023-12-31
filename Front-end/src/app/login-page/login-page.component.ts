import { Component } from '@angular/core';
import { UserService } from '../service/user/user.service';
import { LoginUserResult as LoginUser } from '../service/user/login-user';

import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { NgIf } from '@angular/common';
import { FormControl, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { async } from 'rxjs';


@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
  standalone: true,
  imports: [
    FormsModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    NgIf
  ],
})
export class LoginPageComponent {
  
  hide = true;
  
  email = new FormControl('', [Validators.required, Validators.email]);
  
  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  userData : LoginUser = {
    email : "",
    password : ""
  }

  constructor(private service : UserService, public router : Router) { }

  login(){
    this.service.login(this.userData)
    .subscribe(res => {
        sessionStorage.setItem("UserId", res.value)
        this.router.navigate(['/feed'])
        window.location.reload();
        console.log(sessionStorage.getItem("UserId"))

      })
  }

}
