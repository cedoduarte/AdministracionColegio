import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProfesorService } from '../../../services/profesor.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-profesor-create',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [ProfesorService],
  templateUrl: './profesor-create.component.html',
  styleUrl: './profesor-create.component.css'
})
export class ProfesorCreateComponent {
  profesorService = inject(ProfesorService);
  toastr = inject(ToastrService);
  
  createProfesorForm = new FormGroup({
    nombre: new FormControl("", Validators.required),
    apellidos: new FormControl("", Validators.required),
    genero: new FormControl("", Validators.required)
  });
  
  handleSubmit() {
    this.profesorService.createProfesor({
      nombre: this.createProfesorForm.value.nombre!,
      apellidos: this.createProfesorForm.value.apellidos!,
      genero: this.createProfesorForm.value.genero!
    }).subscribe(profesorObject => {
      this.toastr.success("Profesor creado correctamente!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
