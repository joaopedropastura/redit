import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-init-page',
  templateUrl: './init-page.component.html',
  styleUrls: ['./init-page.component.css']
})


export class InitPageComponent {

  @Output() colorChanged = new EventEmitter<boolean>();

  protected btnSelected1 = "background-color: aqua;"
  protected btnSelected2 = "rgba(0, 0, 0, 0);"

  protected selected = false
  protected changeBackgroundColor(){
    if (this.selected){
      this.btnSelected2 = "rgba(0, 0, 0, 0);"

    }
    this.btnSelected2 = "background-color: aqua;"
    this.colorChanged.emit(this.selected);
  }

}
