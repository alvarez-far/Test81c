export interface Department {
  codigo: number;
  nombre: string;
}

export interface User {
  id: number;
  nombres: string;
  apellidos: string;
  genero: string;
  cedula: string;
  fechaNacimiento: Date;
  departamento: Department;
  idDepartamento: number;
  cargo: string;
  supervisorInmediato: string;
}

export interface Gender {
  valor: string;
  nombre: string;
}
