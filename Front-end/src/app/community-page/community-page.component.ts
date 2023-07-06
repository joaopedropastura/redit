import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription, concatWith } from 'rxjs';
import { CommunityService } from '../service/community/community.service';
import { UserId } from '../service/user/userId';
import { CommunityPage } from '../service/community/community-page';

@Component({
  selector: 'app-community-page',
  templateUrl: './community-page.component.html',
  styleUrls: ['./community-page.component.css']
})

export class CommunityPageComponent {

  isNotHide : boolean = false
  classtag =  this.isNotHide ? "hide" : "text-description"
  btntag = this.isNotHide ? "Menos" : "Mais"
  btnText = ""
  isMember = false
  
  constructor(private route: ActivatedRoute, private router: Router, private service : CommunityService) { }
  
  communityPage: CommunityPage = {

    userId: '',
    communityName : '',
  }

  ngOnInit(){

    const id = sessionStorage.getItem('UserId')

    if (id === null) {
      console.error("sem id")
      this.router.navigate(["/login"])
      return
    }
    
    this.communityPage.userId = id

    this.route.params.subscribe(params => {
      this.communityPage.communityName = params['communtyName']
    })

    this.service.verifyUser(this.communityPage)
        .subscribe(res => {
            console.log(res.inCommunity)
            console.log(res.members)
            this.isMember = res.inCommunity 
            this.btnText = res.inCommunity ? "Membro" : "Unir-se" 

        })
  }

  ngOnDestroy() {
    // this.subscription.unsubscribe();
 }

  changeVisibily()
  {
    this.isNotHide = !this.isNotHide
    this.classtag =  this.isNotHide ? "hide" : "text-description"
    this.btntag = this.isNotHide ? "Menos" : "Mais"
  }
  
  subscribeBtn()
  {
    if(this.isMember == false)
    {
      this.service.subscription(this.communityPage)
      .subscribe(res => {
        console.log(res)
      })
      window.location.reload();

    }
    else
    {
      this.btnText = "Unir-se" 
    }
  }

}
