import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { GradoService } from '../../../services/grado.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-grado-update',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [GradoService],
  templateUrl: './grado-update.component.html',
  styleUrl: './grado-update.component.css'
})
export class GradoUpdateComponent {
  gradoService = inject(GradoService);
  toastr = inject(ToastrService);

  updateGradoForm = new FormGroup({
    gradoId: new FormControl("", Validators.required),
    nombre: new FormControl("", Validators.required),
    profesorId: new FormControl("", Validators.required),
  });

  idChanged(event: any) {
    const id: number = parseInt(event.target.value);
    this.gradoService.getGradoById(id)
    .subscribe(gradoObject => {
      this.updateGradoForm.setValue({
        gradoId: `${id}`,
        nombre: gradoObject.nombre!,
        profesorId: `${gradoObject.profesorId}`
      });
    }, errorObject => {
      this.updateGradoForm.setValue({
        gradoId: "",
        nombre: "",
        profesorId: ""
      });
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
  
  handleSubmit() {
    this.gradoService.updateGrado({
      id: parseInt(this.updateGradoForm.value.gradoId!),
      nombre: this.updateGradoForm.value.nombre!,
      profesorId: parseInt(this.updateGradoForm.value.profesorId!)
    }).subscribe(gradoObject => {
      this.toastr.success("¡Grado actualizado correctamente!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
