import { Component, Input, OnInit } from '@angular/core';
import { Negotiation } from 'src/app/models/negotations';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-person-negotiations-table',
  templateUrl: './person-negotiations-table.component.html',
  styleUrls: ['./person-negotiations-table.component.css']
})
export class PersonNegotiationsTableComponent implements OnInit {

  @Input()
  personId: string;

  negotiations: Negotiation[];

  constructor(private apiService: ApiService) { }

  async ngOnInit(): Promise<void> {
  }

  async refresh(){
    console.log("Refreshing Table")
    this.negotiations = await this.apiService.getNegotiationsFromPerson(this.personId);
  }

}
