import { Component, OnInit, ɵɵqueryRefresh } from '@angular/core';
import { Order } from 'src/app/models/order';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-orders-table',
  templateUrl: './orders-table.component.html',
  styleUrls: ['./orders-table.component.css']
})
export class OrdersTableComponent implements OnInit {

  orders: Order[]

  constructor(private apiService: ApiService) { }

  async ngOnInit(): Promise<void> {
    await this.refresh();
  }

  async refresh(){
    this.orders = await this.apiService.getOrders();
  }

}
