import { Component, OnInit } from '@angular/core';
import { Stock } from 'src/app/models/stock';
import { StockCertificate } from 'src/app/models/stockCertificate';

@Component({
  selector: 'app-stock-certificate-table',
  templateUrl: './stock-certificate-table.component.html',
  styleUrls: ['./stock-certificate-table.component.css']
})
export class StockCertificateTableComponent implements OnInit {

  stockCertificates : StockCertificate[] = [];

  constructor() { 
    this.stockCertificates.push(<StockCertificate>{
      amount: 10,
      stock: <Stock>{
        name: "stock_1"
      }
    });

    this.stockCertificates.push(<StockCertificate>{
      amount: 5,
      stock: <Stock>{
        name: "stock_2"
      }
    });

    this.stockCertificates.push(<StockCertificate>{
      amount: 200,
      stock: <Stock>{
        name: "stock_3"
      }
    });
  }

  ngOnInit(): void {
  }

}
