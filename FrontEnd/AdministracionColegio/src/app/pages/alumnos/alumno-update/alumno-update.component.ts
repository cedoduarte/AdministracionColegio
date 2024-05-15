import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlumnoService } from '../../../services/alumno.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-alumno-update',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [AlumnoService],
  templateUrl: './alumno-update.component.html',
  styleUrl: './alumno-update.component.css'
})
export class AlumnoUpdateComponent {
  alumnoService = inject(AlumnoService);
  toastr = inject(ToastrService);

  updateAlumnoForm = new FormGroup({
    alumnoId: new FormControl("", Validators.required),
    nombre: new FormControl("", Validators.required),
    apellidos: new FormControl("", Validators.required),
    genero: new FormControl("", Validators.required),
    fechaNacimiento: new FormControl("", Validators.required)
  });

  idChanged(event: any) {
    const id: number = parseInt(event.target.value);
    this.alumnoService.getAlumnoById(id)
    .subscribe(alumnoObject => {
      this.updateAlumnoForm.setValue({
        alumnoId: `${id}`,
        nombre: alumnoObject.nombre!,
        apellidos: alumnoObject.apellidos!,
        genero: alumnoObject.genero!,
        fechaNacimiento: alumnoObject.fechaNacimiento!
      });
    }, errorObject => {
      this.updateAlumnoForm.setValue({
        alumnoId: "",
        nombre: "",
        apellidos: "",
        genero: "",
        fechaNacimiento: ""
      });
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
  
  handleSubmit() {
    this.alumnoService.updateAlumno({
      id: parseInt(this.updateAlumnoForm.value.alumnoId!),
      nombre: this.updateAlumnoForm.value.nombre!,
      apellidos: this.updateAlumnoForm.value.apellidos!,
      genero: this.updateAlumnoForm.value.genero!,
      fechaNacimiento: this.updateAlumnoForm.value.fechaNacimiento!
    }).subscribe(alumnoObject => {
      this.toastr.success("¡Alumno actualizado correctamente!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
