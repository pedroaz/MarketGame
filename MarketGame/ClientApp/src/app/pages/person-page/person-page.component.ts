import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Person } from 'src/app/models/person';
import { ApiService } from 'src/app/services/api.service';


@Component({
  selector: 'app-person-page',
  templateUrl: './person-page.component.html',
  styleUrls: ['./person-page.component.css']
})
export class PersonPageComponent implements OnInit {

  id: string;
  person : Person = <Person>{};

  constructor(private route: ActivatedRoute, private apiService : ApiService) { }

  async ngOnInit(): Promise<void> {
    this.id = this.route.snapshot.paramMap.get('id');
    this.person = await this.apiService.getPersonById(this.id);
  }

}
