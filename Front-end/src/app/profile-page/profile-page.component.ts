import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../service/user/user.service';
import { UserId } from '../service/user/userId';
import { UserProfile } from '../service/user/profile-user';

@Component({
  selector: 'app-profile-page',
  templateUrl: './profile-page.component.html',
  styleUrls: ['./profile-page.component.css']
})
export class ProfilePageComponent {
  box = document.getElementById('text-description');
  
  data : UserProfile = {
    name: '',
    userName: '',
    userPhoto: '',
    userPhotoBackground: '',
    bornDate: new Date,
    assignDate: new Date,
    postList: []
  }
  
  constructor(private route : ActivatedRoute, private service : UserService) { }
  
  ngOnInit(){

    const id = sessionStorage.getItem('UserId')

    if (id ===  null){
      console.error("sem id")
      return
    }

    const userId: UserId = {
      userId: id
  }
    this.service.userInfo(userId)
    .subscribe(res => {
      this.data.userName = res.userName
      this.data.name = res.name
      this.data.assignDate = res.assignDate
      this.data.bornDate = res.bornDate
      this.data.postList = res.postList
    })

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
