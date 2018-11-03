import { BaseModel } from "./base";

export class User extends BaseModel {
    Id: string;
    Name: string;
    Username: string;
    Email: string;
}