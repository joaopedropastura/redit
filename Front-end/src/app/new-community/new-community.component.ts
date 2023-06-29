import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { NewCommunity } from '../service/community/new-community';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { CommunityService } from '../service/community/community.service';
import { CommonModule } from '@angular/common';
import { MatMenuModule } from '@angular/material/menu';

@Component({
  selector: 'app-new-community',
  templateUrl: './new-community.component.html',
  styleUrls: ['./new-community.component.css'],
  standalone: true,
  imports : [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule
  ]
})
export class NewCommunityComponent {

  Error: string = ""
  tempJwt = sessionStorage.getItem("UserId") ?? ''
  CommunityRegister : NewCommunity = 
  {
    jwt : this.tempJwt,
    title : "",
    description : ""
  }
  
  constructor (private service : CommunityService) { }
  
  HasError = () => this.Error !== ""

  newCommunity()
  {
    if (this.Error.trim() === "") {
      this.Error = "Titulo do forum é necessário"
      return
    }

    this.service.add(this.CommunityRegister)

    .subscribe(res => {
      this.Error = res.message
    })
  }
}
