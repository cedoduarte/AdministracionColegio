import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-profesores',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './profesores.component.html',
  styleUrl: './profesores.component.css'
})
export class ProfesoresComponent {
  router = inject(Router);

  goToHomePage() {
    this.router.navigate(["/"]);
  }

  goToCrearProfesoresPage() {
    this.router.navigate(["/profesores/profesor-create"]);
  }

  goToLeerProfesoresPage() {
    this.router.navigate(["/profesores/profesor-read"]);
  }

  goToEliminarProfesoresPage() {
    this.router.navigate(["/profesores/profesor-delete"]);
  }

  goToActualizarProfesoresPage() {
    this.router.navigate(["/profesores/profesor-update"]);
  }
}
