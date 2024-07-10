export class StaticClass {
  static value:any = 0
  static getValue<T>(): T {
    return this?.value as T;
  }
  static setValue<T>(value: T): void {
    StaticClass.value = value;
  }
}

StaticClass.setValue<Number>(6)
console.log(StaticClass.getValue<Number>(),"Static")