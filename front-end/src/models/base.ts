export class BaseModel {

    static fromData(data: any) {
        if(data == null) return null;
        return Object.assign(new this(), data);
    }

}