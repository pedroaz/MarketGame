import { Component, OnInit } from '@angular/core';
import { HelperService } from 'src/app/services/helper/helper.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {

  constructor(private helperService: HelperService) { 
    
  }

  ngOnInit(): void {
    this.helperService.pingServer();
  }

}
