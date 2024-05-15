import { Component, inject, OnInit } from '@angular/core';
import { ProfesorService } from '../../../services/profesor.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IProfesorViewModel } from '../../../shared/interfaces';

@Component({
  selector: 'app-profesor-read',
  standalone: true,
  imports: [HttpClientModule],
  providers: [ProfesorService],
  templateUrl: './profesor-read.component.html',
  styleUrl: './profesor-read.component.css'
})
export class ProfesorReadComponent implements OnInit {
  profesorService = inject(ProfesorService);
  toastr = inject(ToastrService);
  profesorList: IProfesorViewModel[] = [];

  ngOnInit() {
    this.profesorService.getProfesorList(true, "")
    .subscribe(profesorArray => {
      this.profesorList = profesorArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
