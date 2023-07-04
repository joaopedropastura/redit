import { Component } from '@angular/core';
import { concatWith } from 'rxjs';

@Component({
  selector: 'app-community-page',
  templateUrl: './community-page.component.html',
  styleUrls: ['./community-page.component.css']
})

export class CommunityPageComponent {

  isNotHide : boolean = false
  
  classtag =  this.isNotHide ? "hide" : "text-description"
  btntag = this.isNotHide ? "Menos" : "Mais"

  changeVisibily()
  {
    this.isNotHide = !this.isNotHide
    this.classtag =  this.isNotHide ? "hide" : "text-description"
    this.btntag = this.isNotHide ? "Menos" : "Mais"
  }
  

}
