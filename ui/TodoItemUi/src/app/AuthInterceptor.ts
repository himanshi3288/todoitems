import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';

import { Observable } from 'rxjs';
import { LocalStorageService } from './LocalStorageService';
import { Injector, Injectable } from '@angular/core';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    /**
     *
     */
    constructor(public inj: Injector ) {
       
    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        

        if  (request.url.indexOf("/login") != -1  || request.url.indexOf("/register") != -1  ){
           
            return next.handle(request);    
        }

        
        const localStorageService: LocalStorageService = this.inj.get(LocalStorageService);
        
        const token = localStorageService.get<string>("token");
        const clonedRequest = request.clone({
            setHeaders: {
              Authorization: `Bearer ${token}`
            }
          });
          
        return next.handle(clonedRequest);
    }
}