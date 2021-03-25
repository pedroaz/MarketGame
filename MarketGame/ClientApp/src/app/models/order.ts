import { Person } from "./person";
import { Stock } from "./stock";

export interface Order{
    orderType: string;
    orderStatus: string;
    stock: Stock;
    amount: number;
    value: number;
    person: Person;
}