
interface Array<T> {
    contains(item): boolean;
    removeFirstByProp(prop, value): void
}
Array.prototype.contains = function(item: any){
    return this.indexOf(item) > -1;
}
Array.prototype.removeFirstByProp = function(prop: string, value: any){
    let index;
    for(let i = 0; i < this.length; i++){
        if(this[i][prop] == value){
            index = i;
            break;
        }
    }
    if(index !== undefined){
        this.splice(index, 1);
    }
}
