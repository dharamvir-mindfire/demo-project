export class GenericClass<T> {
  private value: T;
  constructor(value: T) {
    this.value = value;
  }
  getValue(): T {
    return this?.value;
  }
  setValue(value: T): void {
    this.value = value;
  }
}
const generic = new GenericClass<number>(0)
generic.setValue(4)
console.log(generic.getValue(),"generic")