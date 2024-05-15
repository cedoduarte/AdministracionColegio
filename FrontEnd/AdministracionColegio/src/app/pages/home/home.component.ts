import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  router = inject(Router);

  goToAlumnosControlPage() {
    this.router.navigate(["/alumnos"]);
  }

  goToProfesoresControlPage() {
    this.router.navigate(["/profesores"]);
  }
  goToGradosControlPage() {
    this.router.navigate(["/grados"]);
  }

  goToAlumnosGradosControlPage() {
    this.router.navigate(["/alumnos-grados"]);
  }
}
