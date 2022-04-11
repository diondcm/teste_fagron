import { Component, OnInit } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';
import { BrowserModule } from '@angular/platform-browser';
import { ContentLeftMenuComponent } from './content-left-menu/content-left-menu.component';
import { ContentBodyComponent } from './content-body/content-body.component';
import { Router } from '@angular/router';


@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent implements OnInit {
	constructor(private router: Router) { }
  
  ngOnInit() {
    console.log(this.router.url);
    console.log( window.location.href);
  }
  

}
