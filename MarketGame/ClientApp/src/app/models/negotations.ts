import { Person } from "./person";
import { Stock } from "./stock";

export interface Negotiation{
    id: number;
    stock: Stock;
    buyer: Person;
    seller: Person;
    amount: number;
    value: number;
    time: Date;
    timeFormatted: string;
}