import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { LocalStorageService } from '../LocalStorageService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private http: HttpClient
    , private localStorageService: LocalStorageService
    , private router: Router) { }

  ngOnInit() {
  }

  headers={
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  login() {
    this.http.post(environment.apiUrl + "Authentication/Login", null, this.headers).subscribe(
      x => {
        this.localStorageService.set("token", x);
        this.router.navigate(["items"]);
      }
    )
  }

}
