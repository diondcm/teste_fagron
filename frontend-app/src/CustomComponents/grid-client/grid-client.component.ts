import { Component,NgModule, Injectable, OnInit } from '@angular/core';
import axios, { Axios } from 'axios'; 
import {BrowserModule} from '@angular/platform-browser'
import { ServicesApi } from 'src/Services/ServicesApi';
import { NgxPaginationModule } from 'ngx-pagination';
import { IClientes } from 'src/Services/ServicesModel/Interface/ICliente';

@Component({
  selector: 'app-grid-client',
  templateUrl: './grid-client.component.html',
  styleUrls: ['./grid-client.component.css']
})

export class GridClientComponent implements OnInit {

  POSTS: any;
  page = 1;
  count = 0;
  tableSize = 7;
  tableSizes = [6, 12 , 18, 40];

  currentIndex: number = 1;

  title = 'frontend-app';

  response: IClientes[] = [];
  constructor(private postServiceCliente: ServicesApi) { }

  
  ngOnInit(): void {
    this.fetchPosts();
  }  

  async fetchPosts(): Promise<void> {
    var responseCliente =  await this.postServiceCliente.getAll<IClientes>(); 
    this.POSTS = responseCliente;
  }

  onTableDataChange(event: any){
    this.page = event;
    this.fetchPosts();
  }  

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.fetchPosts();
  }  

}