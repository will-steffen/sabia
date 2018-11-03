import { BaseModel } from "./base";

export class User extends BaseModel {
    id: string;
    name: string;
    username: string;
    email: string;
}