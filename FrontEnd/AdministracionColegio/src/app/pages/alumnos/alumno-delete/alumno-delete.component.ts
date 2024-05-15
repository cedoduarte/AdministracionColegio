import { Component, inject, OnInit } from '@angular/core';
import { AlumnoService } from '../../../services/alumno.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IAlumnoViewModel } from '../../../shared/interfaces';
import { DeleteConfirmationDialogComponent } from './delete-confirmation-dialog/delete-confirmation-dialog.component';

@Component({
  selector: 'app-alumno-delete',
  standalone: true,
  imports: [HttpClientModule, DeleteConfirmationDialogComponent],
  providers: [AlumnoService],
  templateUrl: './alumno-delete.component.html',
  styleUrl: './alumno-delete.component.css'
})
export class AlumnoDeleteComponent implements OnInit {
  alumnoService = inject(AlumnoService);
  toastr = inject(ToastrService);
  alumnoList: IAlumnoViewModel[] = [];
  showDeletionDialog: boolean = false;
  deletionId: number = -1;

  ngOnInit() {
    this.populateAlumnoTable();    
  }  

  populateAlumnoTable() {
    this.alumnoService.getAlumnoList(true, "")
    .subscribe(alumnoArray => {
      this.alumnoList = alumnoArray;      
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }

  handleDeletionResponse(result: boolean) {
    if (result) {
      this.alumnoService.deleteAlumno(this.deletionId)
      .subscribe(alumnoObject => {
        this.populateAlumnoTable();      
      }, errorObject => {
        this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
      });  
    }
    this.showDeletionDialog = false;
  }

  deleteAlumno(id: number) {
    this.deletionId = id;
    this.showDeletionDialog = true;  
  }
}
