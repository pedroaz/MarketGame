import { Stock } from "./stock";

export interface StockCertificate{
    stock: Stock;
    id: number;
    name: string;
    money: number;
}