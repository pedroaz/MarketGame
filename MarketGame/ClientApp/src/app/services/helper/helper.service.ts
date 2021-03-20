import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HelperService {

  private httpClient: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.httpClient = http;
    this.baseUrl = baseUrl;
   }

  pingServer(){
    this.httpClient.get<Boolean>(this.baseUrl + 'api/ping').subscribe(result => {
      console.log("Server is: " + result);
    }, 
    error => console.error(error));
  }
}
