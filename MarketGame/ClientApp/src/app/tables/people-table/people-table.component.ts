import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/models/person';

@Component({
  selector: 'app-people-table',
  templateUrl: './people-table.component.html',
  styleUrls: ['./people-table.component.css']
})
export class PeopleTableComponent implements OnInit {

  people: Person[] = [];
  cols: any[];

  constructor() { 

    this.cols = [
      {field: 'id', header: 'Id'},
      {field: 'money', header: 'Money'},
      {field: 'name', header: 'Name'},
      {field: 'stockCertificates', header: 'StockCertificates'}
  ];


    this.people.push(<Person>{
      id: 0,
      money: 10,
      name: "Pedro",
      stockCertificates: null
    });

    this.people.push(<Person>{
      id: 1,
      money: 100,
      name: "Carol",
      stockCertificates: null
    });

  }

  selectPerson(id: number){
    console.log("Selecting person with id: " + id);
  }

  ngOnInit(): void {
  }

}
