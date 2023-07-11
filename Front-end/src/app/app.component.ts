import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FeedPageService } from './service/feed-page.service';
import { UserId } from './service/user/userId';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})


export class AppComponent {
  title = 'Front-end';
  constructor( public router : Router, private service : FeedPageService ) {  }
  ngOnInit() {
    const id = sessionStorage.getItem('UserId')

    if (id === null) {
        console.error("sem id")
        this.router.navigate(["/initial"])
        return
    } 
    else {
      this.router.navigate(["feed"])
      return
    }
  }
}
