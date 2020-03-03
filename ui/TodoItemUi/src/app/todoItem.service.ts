import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";
import { map } from "rxjs/operators";
import{TodoItem} from './models';


@Injectable({
    providedIn: 'root'
})
export class TodoItemService {
    /**
     *
     */
    constructor(private http: HttpClient) {

    }

    add(item: TodoItem): Observable<TodoItem> {
        return this.http.post(environment.apiUrl + "TodoItem", item).pipe(map(
            (response: TodoItem) => { return response }
        ));
    }

    get(): Observable<TodoItem[]> {
        return this.http.get(environment.apiUrl + "TodoItem").pipe(map(
            (response: TodoItem[]) => { return response }
        ));
    }

    edit(item: TodoItem): Observable<TodoItem> {
        return this.http.put(environment.apiUrl + "TodoItem", item).pipe(map(
            (response: TodoItem) => { return response }
        ));
    }

    delete(itemId: number): Observable<boolean> {
        return this.http.delete(environment.apiUrl + "TodoItem/" + itemId).pipe(map(
            (response: boolean) => { return response }
        ));
    }
}