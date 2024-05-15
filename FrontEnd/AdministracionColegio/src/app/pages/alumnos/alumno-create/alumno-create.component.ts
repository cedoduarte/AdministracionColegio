import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlumnoService } from '../../../services/alumno.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-alumno-create',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [AlumnoService],
  templateUrl: './alumno-create.component.html',
  styleUrl: './alumno-create.component.css'
})
export class AlumnoCreateComponent {
  alumnoService = inject(AlumnoService);
  toastr = inject(ToastrService);

  createAlumnoForm = new FormGroup({
    nombre: new FormControl("", Validators.required),
    apellidos: new FormControl("", Validators.required),
    genero: new FormControl("", Validators.required),
    fechaNacimiento: new FormControl("", Validators.required)
  });
  
  hasNumbers(input: string): boolean {
    for (let i = 0; i < input.length; i++) {
      let numericValue = parseInt(input.at(i)!);
      if (!isNaN(numericValue)) {
        return true;
      }
    }
    return false;
  }

  handleSubmit() {
    const name: string = this.createAlumnoForm.value.nombre!;
    const lastname: string = this.createAlumnoForm.value.apellidos!;

    if (this.hasNumbers(name)) {
      this.toastr.error("¡El nombre no puede tener números!");
      return;
    }
    if (this.hasNumbers(lastname)) {
      this.toastr.error("¡El apellido no puede tener números!");
      return;
    }

    this.alumnoService.createAlumno({
      nombre: this.createAlumnoForm.value.nombre!,
      apellidos: this.createAlumnoForm.value.apellidos!,
      genero: this.createAlumnoForm.value.genero!,
      fechaNacimiento: this.createAlumnoForm.value.fechaNacimiento!
    }).subscribe(alumnoObject => {
      this.toastr.success("¡Alumno creado correctamente!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
