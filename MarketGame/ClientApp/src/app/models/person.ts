import { Negotiation } from "./negotations";
import { StockCertificate } from "./stockCertificate";

export interface Person{
    stockCertificates: StockCertificate[]
    id: number;
    name: string;
    money: number;
}