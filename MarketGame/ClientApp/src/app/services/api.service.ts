import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Negotiation } from '../models/negotations';
import { Order } from '../models/order';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private httpClient: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    this.httpClient = http;
    this.baseUrl = baseUrl;
   }

  async pingServer(){
    return await this.httpClient.get<Boolean>(this.baseUrl + 'api/ping').toPromise();
  }

  async getPeople(){
    return await this.httpClient.get<Person[]>(this.baseUrl + 'api/People').toPromise();
  }

  async getPersonById(id: string){
    return await this.httpClient.get<Person>(this.baseUrl + 'api/PeopleById?id='+id).toPromise();
  }

  async getOrders(){
    return await this.httpClient.get<Order[]>(this.baseUrl + 'api/Orders').toPromise();
  }

  async getNegotiations(){
    return await this.httpClient.get<Negotiation[]>(this.baseUrl + 'api/Negotations').toPromise();
  }

  async getNegotiationsFromPerson(id: string){
    return await this.httpClient.get<Negotiation[]>(this.baseUrl + 'api/NegotationsFromPerson?id='+id).toPromise();
  }
}
