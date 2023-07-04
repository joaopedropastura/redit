import { MatFormFieldControl } from '@angular/material/form-field';
import { Observable, concatWith, map, startWith } from 'rxjs';
import {Component, OnInit} from '@angular/core';
import {FormControl, FormsModule, ReactiveFormsModule} from '@angular/forms';
import {NgFor, AsyncPipe} from '@angular/common';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { ActivatedRoute, Router } from '@angular/router';
import { MatMenuModule } from '@angular/material/menu';
import { SearchCommunityComponent } from "../search-community/search-community.component";
import { PostComponent } from "../post/post.component";
import { FeedPageService } from '../service/feed-page.service';
import { UserId } from '../service/user/userId';
import { CommunityList } from '../service/community/communityList';
import { HttpErrorResponse } from '@angular/common/http';


@Component({
    selector: 'app-feed-page',
    templateUrl: './feed-page.component.html',
    styleUrls: ['./feed-page.component.css'],
    standalone: true,
    imports: [FormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatAutocompleteModule,
        ReactiveFormsModule,
        NgFor,
        AsyncPipe,
        MatIconModule,
        MatButtonModule,
        MatMenuModule,
        SearchCommunityComponent,
        PostComponent,
    ]
})
export class FeedPageComponent {
    
  constructor( public router : Router, private service : FeedPageService ) {  }
  
  showForms()
  {
    this.router.navigate(['/new-community'])
  }

  showPost()
  {
    this.router.navigate(['/new-post'])
  }
  
}
