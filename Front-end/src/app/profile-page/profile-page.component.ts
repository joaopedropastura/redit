import { Component } from '@angular/core';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent {
  box = document.getElementById('text-description');
  
  ngOnInit(){
    
  }

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
