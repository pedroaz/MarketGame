import { Component, Input, OnInit } from '@angular/core';
import { Negotiation } from 'src/app/models/negotations';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-negotiations-table',
  templateUrl: './negotiations-table.component.html',
  styleUrls: ['./negotiations-table.component.css']
})
export class NegotiationsTableComponent implements OnInit {

  negotiations: Negotiation[]

  constructor(private apiService: ApiService) { }

  async ngOnInit(): Promise<void> {
    await this.refresh();
  }

  async refresh(){
    console.log("Refreshing Table")
    this.negotiations = await this.apiService.getNegotiations();
  }

}
