import { Component, inject, OnInit } from '@angular/core';
import { GradoService } from '../../../services/grado.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IGradoViewModel } from '../../../shared/interfaces';

@Component({
  selector: 'app-grado-delete',
  standalone: true,
  imports: [HttpClientModule],
  providers: [GradoService],
  templateUrl: './grado-delete.component.html',
  styleUrl: './grado-delete.component.css'
})
export class GradoDeleteComponent implements OnInit {
  gradoService = inject(GradoService);
  toastr = inject(ToastrService);
  gradoList: IGradoViewModel[] = [];

  ngOnInit() {
    this.populateGradoTable();
  }

  populateGradoTable() {
    this.gradoService.getGradoList(true, "")
    .subscribe(gradoArray => {
      this.gradoList = gradoArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }

  deleteGrado(id: number) {
    this.gradoService.deleteGrado(id)
    .subscribe(gradoObject => {
      this.populateGradoTable();
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    }); 
  }
}
