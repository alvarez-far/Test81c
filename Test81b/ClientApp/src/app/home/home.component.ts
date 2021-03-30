import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Departamento {
  codigo: number;
  nombre: string;
}

interface Users {
  id: number;
  nombres: string;
  apellidos: string;
  genero: string;
  cedula: string;
  fechaNacimiento: Date;
  departamento: Departamento;
  cargo: string;
  supervisorInmediato: string;
}


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})


export class HomeComponent {
  public users: Users[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Users[]>(baseUrl + 'api/users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));
  }
}
