import { Component, OnInit } from '@angular/core';
import { TodoItemService } from '../todoItem.service';
import{TodoItem} from '../models';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-todoitems',
  templateUrl: './todoitems.component.html',
  styleUrls: ['./todoitems.component.css']
})
export class TodoitemsComponent implements OnInit {

  Items: TodoItem[]=[];

  constructor(private todoItemService: TodoItemService, private tostr: ToastrService) { }

  ngOnInit() {
    this.loadItems();
  }

  loadItems() {
    this.todoItemService.get().subscribe(x => {
      this.Items = x;
    });
  }

  addNew() {
    let newItem = new TodoItem(true);
    this.Items.push(newItem);
  }

  OnItemDeleted(itemIndex){
    this.tostr.success("Item deleted successfully.");
    this.Items.splice(itemIndex, 1);
  }

}
