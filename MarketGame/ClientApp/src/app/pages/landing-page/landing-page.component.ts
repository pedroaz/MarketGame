import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {

  isServerOnline: Boolean = false;

  constructor(private apiService: ApiService) { 
    
  }

  async ngOnInit(): Promise<void> {
    this.isServerOnline = await this.apiService.pingServer();
  }

}
