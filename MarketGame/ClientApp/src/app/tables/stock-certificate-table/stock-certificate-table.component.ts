import { Component, Input, OnInit } from '@angular/core';
import { Stock } from 'src/app/models/stock';
import { StockCertificate } from 'src/app/models/stockCertificate';

@Component({
  selector: 'app-stock-certificate-table',
  templateUrl: './stock-certificate-table.component.html',
  styleUrls: ['./stock-certificate-table.component.css']
})
export class StockCertificateTableComponent implements OnInit {

  @Input()
  stockCertificates : StockCertificate[] = [];

  constructor() { 
    
  }

  ngOnInit(): void {
  }

}
