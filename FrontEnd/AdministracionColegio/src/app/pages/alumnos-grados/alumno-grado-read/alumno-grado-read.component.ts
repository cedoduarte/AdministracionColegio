import { Component, inject, OnInit } from '@angular/core';
import { AlumnoGradoService } from '../../../services/alumno-grado.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IAlumnoGradoViewModel } from '../../../shared/interfaces';

@Component({
  selector: 'app-alumno-grado-read',
  standalone: true,
  imports: [HttpClientModule],
  providers: [AlumnoGradoService],
  templateUrl: './alumno-grado-read.component.html',
  styleUrl: './alumno-grado-read.component.css'
})
export class AlumnoGradoReadComponent implements OnInit {
  alumnoGradoService = inject(AlumnoGradoService);
  toastr = inject(ToastrService);
  alumnoGradoList: IAlumnoGradoViewModel[] = [];

  ngOnInit() {
    this.alumnoGradoService.getAlumnoGradoList(true, "")
    .subscribe(alumnoGradoArray => {
      this.alumnoGradoList = alumnoGradoArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
