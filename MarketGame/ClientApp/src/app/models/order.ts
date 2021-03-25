import { Person } from "./person";
import { Stock } from "./stock";

import {formatDate} from '@angular/common';

export interface Order{
    id: number;
    orderType: string;
    orderStatus: string;
    stock: Stock;
    amount: number;
    value: number;
    person: Person;
    creationTime: Date;
    creationTimeFormatted: string;
}