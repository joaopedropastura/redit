import { MatFormFieldControl } from '@angular/material/form-field';
import { Observable, map, startWith } from 'rxjs';
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
import { FeedPageService } from '../service/feed-page.service';
import { UserId } from '../service/user/userId';
import { CommunityList } from '../service/community/communityList';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-search-community',
  templateUrl: './search-community.component.html',
  styleUrls: ['./search-community.component.css'],
  standalone: true,
  imports: [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    NgFor,
    AsyncPipe,
    MatIconModule,
    MatButtonModule,
    MatMenuModule
  ]
})
export class SearchCommunityComponent {
  constructor( public router : Router, private service : FeedPageService ) { }
  
  myControl = new FormControl('');
  options: string[] = [];
  filteredOptions: Observable<string[]> | undefined;


  ngOnInit() {
    this.filteredOptions = this.myControl.valueChanges.pipe(
      startWith(''),
      map(value => this._filter(value || '')),
    );
    const id = sessionStorage.getItem('UserId')
    
    if (id === null) {
        console.error("sem id")
        this.router.navigate(["/login"])
        return
    }
    
    console.log(this.filteredOptions)
    if ( this.myControl.value != "")
    {
      console.log("mudou")
    }
    const userId: UserId = {
        userId: id
    }
    this.service.communityList(userId)
        .subscribe(res => {
            res.forEach((value) =>{
              console.log(value)
                this.options.push(value.title)
            })
        })
  }

  showForms()
  {
    this.router.navigate(['/new-community'])
  }

  showPost()
  {
    this.router.navigate(['/new-post'])
  }
  private _filter(value: string): string[] {

    const filterValue = value
    if (this.options.includes(filterValue))
    {
      console.log(filterValue)
      this.router.navigate( ["/community-page", filterValue] )
    }
    
    return this.options.filter(option => option.toLowerCase().includes(filterValue));
  
  }

}
