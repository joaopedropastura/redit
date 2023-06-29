import { Component } from '@angular/core';
import { NewUser } from '../service/user/new-user';
import { UserService } from '../service/user/user.service';


import {
  FormControl,
  FormGroupDirective,
  NgForm,
  Validators,
  FormsModule,
  ReactiveFormsModule,
} from '@angular/forms';

import {ErrorStateMatcher} from '@angular/material/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatButtonModule} from '@angular/material/button';
import {MatNativeDateModule} from '@angular/material/core';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatIconModule} from '@angular/material/icon';


import { CommonModule } from '@angular/common';
import { of } from 'rxjs';
import { MatMenuModule } from '@angular/material/menu';

export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}
@Component({
  selector: 'app-new-account-page',
  templateUrl: './new-account-page.component.html',
  styleUrls: ['./new-account-page.component.css'],
  standalone: true,
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatIconModule,
    MatButtonModule,
    MatNativeDateModule,
    MatDatepickerModule,
    CommonModule,
    
  ],

})
export class NewAccountPageComponent {

  constructor(private service : UserService) { }
  messageResponse = ""
  hide = true;
  userRegister : NewUser =
  {
    password : "",
    userName : "",
    email : "",
    name : "",
    cpf : "",
    bornDate : new Date(),
    AssignDate : new Date()
  }
  
  add(){
    this.service.add(this.userRegister)
      .subscribe({
        next(value) {
          sessionStorage.setItem("UsuarioLogadoId", value.message)
        },
        error(err) {
          console.log(err)
        },
        complete() {
          console.log("Cabo")
        },
      })

  }

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  usernameFormControl = new FormControl('', [Validators.required, Validators.minLength(8)]);
  nameFormControl = new FormControl('', [Validators.required]);
  cpfFormControl = new FormControl('', [Validators.required, Validators.minLength(11)]);
}
