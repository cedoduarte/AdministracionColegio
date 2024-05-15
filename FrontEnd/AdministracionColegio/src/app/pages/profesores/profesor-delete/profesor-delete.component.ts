import { Component, inject, OnInit } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IProfesorViewModel } from '../../../shared/interfaces';
import { ProfesorService } from '../../../services/profesor.service';

@Component({
  selector: 'app-profesor-delete',
  standalone: true,
  imports: [HttpClientModule],
  providers: [ProfesorService],
  templateUrl: './profesor-delete.component.html',
  styleUrl: './profesor-delete.component.css'
})
export class ProfesorDeleteComponent implements OnInit {
  profesorService = inject(ProfesorService);
  toastr = inject(ToastrService);
  profesorList: IProfesorViewModel[] = [];

  ngOnInit() {
    this.populateProfesorTable();
  }

  populateProfesorTable() {
    this.profesorService.getProfesorList(true, "")
    .subscribe(profesorArray => {
      this.profesorList = profesorArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }

  deleteProfesor(id: number) {
    this.profesorService.deleteProfesor(id)
    .subscribe(profesorObject => {
      this.populateProfesorTable();
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    }); 
  }
}
