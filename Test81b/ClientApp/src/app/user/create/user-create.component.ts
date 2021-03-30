import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroupDirective, NgForm, Validators } from '@angular/forms';
import { ErrorStateMatcher } from '@angular/material/core';

import { Department, Gender, User } from '../../models/viewModels';

class SelectErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}


@Component({
  selector: 'user-create',
  styleUrls: ['user-create.css'],
  templateUrl: './user-create.component.html',
})
export class UserCreateComponent {
  public genders: Gender[] = [
    { valor: "F", nombre: "Femenino" },
    { valor: "M", nombre: "Masculino" }
  ];
  public departments: Department[];
  public newUser: User = this.getCleanUser();

  //error matchers
  public mandatoryMatcher: SelectErrorStateMatcher = new SelectErrorStateMatcher();
  public mandatorySelect = new FormControl('', [
    Validators.required
  ]);

  private _baseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseURL = baseUrl;

    http.get<Department[]>(baseUrl + 'api/departments').subscribe(result => {
      this.departments = result;
    }, error => console.error(error));

  }

  public createUser(valid): void {
    console.log("CREATE USER", valid);
    if (!valid) {
      return;
    }

    const data = { ...this.newUser };
    data.idDepartamento = data.departamento.codigo;
    data.departamento = null;

    this.http.post(this._baseURL + 'api/users', data)
      .subscribe(
        response => {
          console.log(response);
          alert("Usuario Creado");
          //clear the model so the form "resets"
          this.newUser = this.getCleanUser();

        },
        error => {
          console.log(error);
          alert("Error Creando Usuario");
        });
  }

  private getCleanUser(): User {
    return {
      id: 0,
      nombres: "",
      apellidos: "",
      cargo: "",
      genero: "",
      cedula: "",
      departamento: { codigo: 0, nombre: "" },
      idDepartamento: null,
      fechaNacimiento: new Date(),
      supervisorInmediato: ""
    };
  }
}
