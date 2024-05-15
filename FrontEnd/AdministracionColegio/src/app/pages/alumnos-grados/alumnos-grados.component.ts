import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-alumnos-grados',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './alumnos-grados.component.html',
  styleUrl: './alumnos-grados.component.css'
})
export class AlumnosGradosComponent {
  router = inject(Router);
  
  goToHomePage() {
    this.router.navigate(["/"]);
  }

  goToCrearAlumnoGradoPage() {
    this.router.navigate(["/alumnos-grados/alumno-grado-create"]);
  }

  goToLeerAlumnoGradoPage() {
    this.router.navigate(["/alumnos-grados/alumno-grado-read"]);
  }
  
  goToEliminarAlumnoGradoPage() {
    this.router.navigate(["/alumnos-grados/alumno-grado-delete"]);
  }

  goToActualizarAlumnoGradoPage() {
    this.router.navigate(["/alumnos-grados/alumno-grado-update"]);
  }
}
