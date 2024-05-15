import { Component, inject, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IAlumnoGradoViewModel } from '../../../shared/interfaces';
import { AlumnoGradoService } from '../../../services/alumno-grado.service';

@Component({
  selector: 'app-alumno-grado-delete',
  standalone: true,
  imports: [HttpClientModule],
  providers: [AlumnoGradoService],
  templateUrl: './alumno-grado-delete.component.html',
  styleUrl: './alumno-grado-delete.component.css'
})
export class AlumnoGradoDeleteComponent implements OnInit {
  alumnoGradoService = inject(AlumnoGradoService);
  toastr = inject(ToastrService);
  alumnoGradoList: IAlumnoGradoViewModel[] = [];

  ngOnInit() {
    this.populateAlumnoGradoTable();
  }

  populateAlumnoGradoTable() {
    this.alumnoGradoService.getAlumnoGradoList(true, "")
    .subscribe(alumnoGradoArray => {
      this.alumnoGradoList = alumnoGradoArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }

  deleteAlumnoGrado(id: number) {
    this.alumnoGradoService.deleteAlumnoGrado(id)
    .subscribe(alumnoGradoObject => {
      this.populateAlumnoGradoTable();
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
