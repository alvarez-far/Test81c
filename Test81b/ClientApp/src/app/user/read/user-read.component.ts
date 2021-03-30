import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { User } from '../../models/viewModels';

@Component({
  selector: 'user-read',
  styleUrls: ['user-read.css'],
  templateUrl: './user-read.component.html',
})
export class UserReadComponent {
  public userColumns: string[] = [
    'nombres',
    'apellidos',
    'genero',
    'cedula',
    'fechaNacimiento',
    'departamento',
    'cargo',
    'supervisorInmediato'
  ];
  public users: User[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    http.get<User[]>(baseUrl + 'api/users').subscribe(result => {
      this.users = result;
    }, error => console.error(error));


  }


}
