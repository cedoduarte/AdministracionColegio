import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { GradoService } from '../../../services/grado.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-grado-create',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [GradoService],
  templateUrl: './grado-create.component.html',
  styleUrl: './grado-create.component.css'
})
export class GradoCreateComponent {
  gradoService = inject(GradoService);
  toastr = inject(ToastrService);

  createGradoForm = new FormGroup({
    nombre: new FormControl("", Validators.required),
    profesorId: new FormControl("", Validators.required),
  });
  
  handleSubmit() {
    this.gradoService.createGrado({
      nombre: this.createGradoForm.value.nombre!,
      profesorId: parseInt(this.createGradoForm.value.profesorId!)
    }).subscribe(gradoObject => {
      this.toastr.success("¡Grado creado correctamente!")
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
