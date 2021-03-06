import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public users: Users[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Users[]>(baseUrl + 'api/users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}

interface Departamento {
  Codigo: number;
  Nombre: string;
}

interface Users {
  id: number;
  Nombres: string;
  Apellidos: string;
  Genero: string;
  Cedula: string;
  FechaNacimiento: Date;
  Departamento: Departamento;
  Cargo: string;
  SupervisorInmediato: string;
}
