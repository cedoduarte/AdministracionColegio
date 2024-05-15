import { Component, inject, OnInit } from '@angular/core';
import { GradoService } from '../../../services/grado.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { IGradoViewModel } from '../../../shared/interfaces';

@Component({
  selector: 'app-grado-read',
  standalone: true,
  imports: [HttpClientModule],
  providers: [GradoService],
  templateUrl: './grado-read.component.html',
  styleUrl: './grado-read.component.css'
})
export class GradoReadComponent implements OnInit {
  gradoService = inject(GradoService);
  toastr = inject(ToastrService);
  gradoList: IGradoViewModel[] = [];

  ngOnInit() {
    this.gradoService.getGradoList(true, "")
    .subscribe(gradoArray => {
      this.gradoList = gradoArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
