import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-grados',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './grados.component.html',
  styleUrl: './grados.component.css'
})
export class GradosComponent {
  router = inject(Router);

  goToHomePage() {
    this.router.navigate(["/"]);
  }

  goToCrearGradosPage() {
    this.router.navigate(["/grados/grado-create"]);
  }

  goToLeerGradosPage() {
    this.router.navigate(["/grados/grado-read"]);
  }

  goToEliminarGradosPage() {
    this.router.navigate(["/grados/grado-delete"]);
  }

  goToActualizarGradosPage() {
    this.router.navigate(["/grados/grado-update"]);
  }
}
