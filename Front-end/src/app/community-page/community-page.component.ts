import { Component } from '@angular/core';
import { concatWith } from 'rxjs';

@Component({
  selector: 'app-community-page',
  templateUrl: './community-page.component.html',
  styleUrls: ['./community-page.component.css']
})

export class CommunityPageComponent {
  box = document.getElementById('text-description');
  
  
  isNotHide : boolean = false
  classtag =  this.isNotHide ? "hide" : "text-description"
  // selected = document.querySelector('#text-description')
  // protected moreInfo = 
  moreInfo(){
    // this.selected.setProperty()
    console.log(this.box?.style.width)
  }

  changeVisibily()
  {
    this.isNotHide = !this.isNotHide
    this.classtag =  this.isNotHide ? "hide" : "text-description"
  }


}
