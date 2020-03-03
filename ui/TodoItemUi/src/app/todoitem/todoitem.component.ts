import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TodoItem } from '../models';
import { TodoItemService } from '../todoItem.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-todoitem',
  templateUrl: './todoitem.component.html',
  styleUrls: ['./todoitem.component.css']
})
export class TodoitemComponent implements OnInit {

  @Input() Item: TodoItem;
  @Input() ItemIndex: number;
  @Output() OnItemDeleted: EventEmitter<number> = new EventEmitter<number>();
  IsEditMode: Boolean = false;

  constructor(private todoItemService: TodoItemService, private tostr: ToastrService) { }

  ngOnInit() {
    if (this.Item.Id == 0) {
      this.IsEditMode = true;
    }
  }

  editItem() {
    this.IsEditMode = true;
  }

  deleteItem() {
    if (this.Item.Id !== 0) {
      this.todoItemService.delete(this.Item.Id).subscribe(x => {
        this.OnItemDeleted.emit(this.ItemIndex);
      });
    }
    else {
      this.OnItemDeleted.emit(this.ItemIndex);
    }

  }

  onSave() {
    if (this.Item.Id && this.Item.Id !== 0) {
      this.todoItemService.edit(this.Item).subscribe(x => {
        this.tostr.success("Item updated successfully.");
        this.Item = x;
        this.IsEditMode = false;
      });
    } else {
      this.todoItemService.add(this.Item).subscribe(x => {
        this.tostr.success("Item added successfully.");
        this.Item = x;
        this.IsEditMode = false;
      });
    }
  }

}
