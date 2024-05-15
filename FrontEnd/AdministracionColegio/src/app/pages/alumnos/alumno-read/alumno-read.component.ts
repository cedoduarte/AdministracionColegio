import { Component, inject, OnInit } from '@angular/core';
import { AlumnoService } from '../../../services/alumno.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IAlumnoViewModel } from '../../../shared/interfaces';

@Component({
  selector: 'app-alumno-read',
  standalone: true,
  imports: [HttpClientModule],
  providers: [AlumnoService],
  templateUrl: './alumno-read.component.html',
  styleUrl: './alumno-read.component.css'
})
export class AlumnoReadComponent implements OnInit {
  alumnoService = inject(AlumnoService);
  toastr = inject(ToastrService);
  alumnoList: IAlumnoViewModel[] = [];

  ngOnInit() {
    this.alumnoService.getAlumnoList(true, "")
    .subscribe(alumnoArray => {
      this.alumnoList = alumnoArray;      
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }  
}
