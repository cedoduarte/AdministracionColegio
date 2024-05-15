import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-alumnos',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './alumnos.component.html',
  styleUrl: './alumnos.component.css'
})
export class AlumnosComponent {
  router = inject(Router);

  goToHomePage() {
    this.router.navigate(["/"]);
  }

  goToCrearAlumnosPage() {
    this.router.navigate(["/alumnos/alumno-create"]);
  }

  goToLeerAlumnosPage() {
    this.router.navigate(["/alumnos/alumno-read"]);
  }

  goToEliminarAlumnosPage() {
    this.router.navigate(["/alumnos/alumno-delete"]);
  }

  goToActualizarAlumnosPage() {
    this.router.navigate(["/alumnos/alumno-update"]);
  }
}
