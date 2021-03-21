import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Person } from 'src/app/models/person';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-people-table',
  templateUrl: './people-table.component.html',
  styleUrls: ['./people-table.component.css']
})
export class PeopleTableComponent implements OnInit {

  people: Person[] = [];

  constructor(private apiService: ApiService, private router : Router) { 
  }

  selectPerson(id: number){
    this.router.navigateByUrl("/person/"+id);
  }

  async refresh(){
    this.people = await this.apiService.getPeople();
  }

  async ngOnInit(): Promise<void> {
    await this.refresh();
  }

}
