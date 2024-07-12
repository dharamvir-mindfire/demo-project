export class StaticClass {
  static value: Number = 0
  static getValue<T>(): Number {
    return this?.value;
  }
  static setValue(value: Number): void {
    StaticClass.value = value;
  }
}

StaticClass.setValue(5)
console.log(StaticClass.getValue(),"Static")