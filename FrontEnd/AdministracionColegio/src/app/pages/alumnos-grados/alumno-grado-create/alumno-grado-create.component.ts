import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { AlumnoGradoService } from '../../../services/alumno-grado.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-alumno-grado-create',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [AlumnoGradoService],
  templateUrl: './alumno-grado-create.component.html',
  styleUrl: './alumno-grado-create.component.css'
})
export class AlumnoGradoCreateComponent {
  alumnoGradoService = inject(AlumnoGradoService);
  toastr = inject(ToastrService);

  createAlumnoGradoForm = new FormGroup({
    alumnoId: new FormControl("", Validators.required),
    gradoId: new FormControl("", Validators.required),
    seccion: new FormControl("", Validators.required),
  });
  
  handleSubmit() {
    this.alumnoGradoService.createAlumnoGrado({
      alumnoId: parseInt(this.createAlumnoGradoForm.value.alumnoId!),
      gradoId: parseInt(this.createAlumnoGradoForm.value.gradoId!),
      seccion: this.createAlumnoGradoForm.value.seccion!
    }).subscribe(alumnoGradoObject => {
      this.toastr.success("¡Relación entre Alumno y Grado creada correctamente!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
