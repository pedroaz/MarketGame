import { Stock } from "./stock";

export interface StockCertificate{
    stock: Stock;
    Amount: number;
    ValueWhenBought: number;
}