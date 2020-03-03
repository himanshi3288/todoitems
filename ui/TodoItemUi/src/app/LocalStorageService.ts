/*class for local storage set, get, clear, and remove key*/
import { Injectable } from '@angular/core';
@Injectable({providedIn:"root"})
export class LocalStorageService {
    /*method for set local storage*/
    set<T>(key: string, value: T): void {
        let stringifyJson = JSON.stringify(value);
        localStorage.setItem(key, stringifyJson);
    }
    /*method for get local storage by key*/
    get<T>(key: string): T 
    {
        let obj = JSON.parse(localStorage.getItem(key));
        return obj;
    }
    edit<T>(key:string,value:T):void{

      localStorage[key]=JSON.stringify(value);
    }
    /*method for clear local storage*/
    clearLocalStorage(): void {
        localStorage.clear();
    }
    /*Remove local storage on basis of key*/
    remove(key: string): void {
        localStorage.removeItem(key);
    }
    
    /*check local storage is disable or enable., in case of enable return true,else false.*/
    checkLocalStorageDisable(): boolean {
        try {
            let test = 'test';
            localStorage.setItem(test, test);
            localStorage.removeItem(test);
            return true;
        } catch (e) {
            return false;
        }
    }
}

