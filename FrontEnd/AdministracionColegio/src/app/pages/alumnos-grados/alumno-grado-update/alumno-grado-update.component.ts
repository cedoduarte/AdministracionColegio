import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlumnoGradoService } from '../../../services/alumno-grado.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-alumno-grado-update',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [AlumnoGradoService],
  templateUrl: './alumno-grado-update.component.html',
  styleUrl: './alumno-grado-update.component.css'
})
export class AlumnoGradoUpdateComponent {
  alumnoGradoService = inject(AlumnoGradoService);
  toastr = inject(ToastrService);

  updateAlumnoGradoForm = new FormGroup({
    alumnoGradoId: new FormControl("", Validators.required),
    alumnoId: new FormControl("", Validators.required),
    gradoId: new FormControl("", Validators.required),
    seccion: new FormControl("", Validators.required)
  });

  idChanged(event: any) {
    const id: number = parseInt(event.target.value);
    this.alumnoGradoService.getAlumnoGradoById(id)
    .subscribe(alumnoGradoObject => {
      this.updateAlumnoGradoForm.setValue({
        alumnoGradoId: `${id}`,
        alumnoId: `${alumnoGradoObject.alumnoId}`,
        gradoId: `${alumnoGradoObject.gradoId}`,
        seccion: alumnoGradoObject.seccion!
      });
    }, errorObject => {
      this.updateAlumnoGradoForm.setValue({
        alumnoGradoId: "",
        alumnoId: "",
        gradoId: "",
        seccion: ""
      });
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
  
  handleSubmit() {
    this.alumnoGradoService.updateAlumnoGrado({
      id: parseInt(this.updateAlumnoGradoForm.value.alumnoGradoId!),
      alumnoId: parseInt(this.updateAlumnoGradoForm.value.alumnoId!),
      gradoId: parseInt(this.updateAlumnoGradoForm.value.gradoId!),
      seccion: this.updateAlumnoGradoForm.value.seccion!
    }).subscribe(alumnoGradoObject => {
      this.toastr.success("¡Relación Alumno-Grado actualizada correctamente!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
