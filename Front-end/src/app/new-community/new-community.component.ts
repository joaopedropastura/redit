import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-new-community',
  templateUrl: './new-community.component.html',
  styleUrls: ['./new-community.component.css'],
  standalone: true,
  imports : [
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
  ]
})
export class NewCommunityComponent {

}
