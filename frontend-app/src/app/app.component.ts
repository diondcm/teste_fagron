import { Component , NgModule, Injectable} from '@angular/core';
import axios, { Axios } from 'axios'; 
import {BrowserModule} from '@angular/platform-browser'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  title = 'frontend-app';
}
