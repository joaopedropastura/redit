import { NgFor } from '@angular/common';
import {Component, Input} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { Router } from '@angular/router';
import { FeedPageService } from '../service/feed-page.service';
import { UserId } from '../service/user/userId';
import { PostCard } from '../service/post/post-card';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
  standalone: true,
  imports: [
    MatCardModule,
    MatButtonModule, 
    NgFor
  ]
})
export class PostComponent {
    constructor( public router : Router, private service : FeedPageService ) {  }
    

    @Input() post : PostCard = {
      title: '',
      userName: '',
      communityName: '',
      postData: '',
      userPhoto: "../../assets/img/dog.png",
      photoPost: "../../assets/img/images.png"
    } 

   ngOnInit() {
    const id = sessionStorage.getItem('UserId')

    if (id === null) {
        console.error("sem id")
        this.router.navigate(["/login"])
        return
    }

    const userId: UserId = {
        userId: id
    }

    // this.service.postsLists(userId)
    // .subscribe(res => {
    //   res.forEach(element => {
    //     this.post.title = element.title
    //     this.post.userName = element.userName
    //     this.post.postData = element.postData
    //     this.post.communityName = element.communityName

    //   });
    // })
  }
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
