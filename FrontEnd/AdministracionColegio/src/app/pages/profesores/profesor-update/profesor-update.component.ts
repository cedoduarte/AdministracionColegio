import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProfesorService } from '../../../services/profesor.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profesor-update',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [ProfesorService],
  templateUrl: './profesor-update.component.html',
  styleUrl: './profesor-update.component.css'
})
export class ProfesorUpdateComponent {
  profesorService = inject(ProfesorService);
  toastr = inject(ToastrService);

  updateProfesorForm = new FormGroup({
    profesorId: new FormControl("", Validators.required),
    nombre: new FormControl("", Validators.required),
    apellidos: new FormControl("", Validators.required),
    genero: new FormControl("", Validators.required)
  });

  idChanged(event: any) {
    const id: number = parseInt(event.target.value);
    this.profesorService.getProfesorById(id)
    .subscribe(profesorObject => {
      this.updateProfesorForm.setValue({
        profesorId: `${id}`,
        nombre: profesorObject.nombre!,
        apellidos: profesorObject.apellidos!,
        genero: profesorObject.genero!
      });
    }, errorObject => {
      this.updateProfesorForm.setValue({
        profesorId: "",
        nombre: "",
        apellidos: "",
        genero: ""
      });
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
  
  handleSubmit() {
    this.profesorService.updateProfesor({
      id: parseInt(this.updateProfesorForm.value.profesorId!),
      nombre: this.updateProfesorForm.value.nombre!,
      apellidos: this.updateProfesorForm.value.apellidos!,
      genero: this.updateProfesorForm.value.genero!
    }).subscribe(profesorObject => {
      this.toastr.success("¡Profesor actualizado correctamente!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
