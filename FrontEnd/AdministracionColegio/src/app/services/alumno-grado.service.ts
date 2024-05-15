import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, share } from 'rxjs';
import { IAlumnoGradoViewModel, ICreateAlumnoGradoCommand, IUpdateAlumnoGradoCommand } from '../shared/interfaces';
import { URL_ALUMNO_GRADO_CREATE, URL_ALUMNO_GRADO_DELETE, URL_ALUMNO_GRADO_GET_BY_ID, URL_ALUMNO_GRADO_GET_LIST, URL_ALUMNO_GRADO_UPDATE } from '../shared/constants';

@Injectable({
  providedIn: 'root'
})
export class AlumnoGradoService {
  http = inject(HttpClient);

  createAlumnoGrado(request: ICreateAlumnoGradoCommand): Observable<IAlumnoGradoViewModel> {
    return this.http.post<IAlumnoGradoViewModel>(URL_ALUMNO_GRADO_CREATE, request).pipe(share());
  }

  updateAlumnoGrado(request: IUpdateAlumnoGradoCommand): Observable<IAlumnoGradoViewModel> {
    return this.http.put<IAlumnoGradoViewModel>(URL_ALUMNO_GRADO_UPDATE, request).pipe(share());
  }
  
  deleteAlumnoGrado(id: number): Observable<IAlumnoGradoViewModel> {
    return this.http.delete<IAlumnoGradoViewModel>(`${URL_ALUMNO_GRADO_DELETE}/${id}`).pipe(share());
  }

  getAlumnoGradoById(id: number): Observable<IAlumnoGradoViewModel> {
    return this.http.get<IAlumnoGradoViewModel>(`${URL_ALUMNO_GRADO_GET_BY_ID}/${id}`).pipe(share());
  }

  getAlumnoGradoList(getAll: boolean, keyword: string): Observable<IAlumnoGradoViewModel[]> {
    return this.http.get<IAlumnoGradoViewModel[]>(`${URL_ALUMNO_GRADO_GET_LIST}?getAll=${getAll}&keyword=${keyword}`).pipe(share());
  }
}