import { Component, OnInit } from '@angular/core';

import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { PostService } from '../service/post/post.service';
import { AsyncPipe, CommonModule, NgFor } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatChipsModule } from '@angular/material/chips';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { NewPost } from '../service/post/new-post';
import { Router } from '@angular/router';
import { SearchCommunityComponent } from "../search-community/search-community.component";
import { Observable, map, startWith } from 'rxjs';
import { UserId } from '../service/user/userId';
import { FeedPageService } from '../service/feed-page.service';
import { CommunityList } from '../service/community/communityList';

@Component({
  selector: 'app-new-post',
  templateUrl: './new-post.component.html',
  styleUrls: ['./new-post.component.css'],
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    AsyncPipe,
    MatChipsModule,
    SearchCommunityComponent,
    ReactiveFormsModule,
    NgFor,
    AsyncPipe,
    MatIconModule,
    MatButtonModule,
    MatMenuModule
  ]
})

export class NewPostComponent {
  
  myControl = new FormControl('');
  options: string[] = [];
  communityList : CommunityList[] = []
  filteredOptions: Observable<string[]> | undefined;

  PostRegister: NewPost = {
    userId: '',
    title: '',
    postData: '',
    communityId: 0
  }
  
  constructor(private service: PostService, public router: Router, private service2: FeedPageService) {

    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
    const id = sessionStorage.getItem("UserId")

    if (id === null) {
      console.log("sem id")
      this.router.navigate(["/login"])
      return
    }
    this.PostRegister.userId = id

    const userId: UserId = {
      userId: id
    }

    this.service2.communityList(userId)
      .subscribe(res => {
        res.forEach((value) => {
          this.options.push(value.title)
          this.communityList.push(value)
          console.log(this.communityList)
        })
      })
  }


  newPost() {
    this.service.add(this.PostRegister)
      .subscribe(res => {
        console.log(res)
      })
    console.log(this.PostRegister)
    this.router.navigate(['/feed'])
  }

  private _filter(value: string): string[] {

    const filterValue = value
    if (this.options.includes(filterValue))
    {
      console.log(filterValue)
      const temp = this.communityList.filter(x => x.title == filterValue)[0].id
      this.PostRegister.communityId = temp
    }
    return this.options.filter(option => option.toLowerCase().includes(filterValue));

  }
}
