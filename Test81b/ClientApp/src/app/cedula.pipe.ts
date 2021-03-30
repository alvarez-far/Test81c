import { Pipe, PipeTransform } from '@angular/core';

@Pipe({ name: 'cedula' })
export class CedulaPipe implements PipeTransform {
  transform(x: string): string {
    return `${x.substr(0, 3)}-${x.substr(3, 7)}-${x.substr(10, 1)}`;
  }
}
