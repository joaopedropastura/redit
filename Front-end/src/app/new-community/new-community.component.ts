import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NewCommunity } from '../service/user/new-community';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';


@Component({
  selector: 'app-new-community',
  templateUrl: './new-community.component.html',
  styleUrls: ['./new-community.component.css'],
  standalone: true,
  imports : [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule
  ]
})
export class NewCommunityComponent {

  tempJwt = sessionStorage.getItem("UserId") ?? ''
  
  CommunityRegister : NewCommunity = 
  {
    jwt : this.tempJwt,
    title : "",
    description : ""
  }

  newCommunity()
  {

  }
}
