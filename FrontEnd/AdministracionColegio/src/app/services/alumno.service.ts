import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, share } from 'rxjs';
import { IAlumnoViewModel, ICreateAlumnoCommand, IUpdateAlumnoCommand } from '../shared/interfaces';
import { URL_ALUMNO_CREATE, URL_ALUMNO_DELETE, URL_ALUMNO_GET_BY_ID, URL_ALUMNO_GET_LIST, URL_ALUMNO_UPDATE } from '../shared/constants';

@Injectable({
  providedIn: 'root'
})
export class AlumnoService {
  http = inject(HttpClient);

  createAlumno(request: ICreateAlumnoCommand): Observable<IAlumnoViewModel> {
    return this.http.post<IAlumnoViewModel>(URL_ALUMNO_CREATE, request).pipe(share());
  }

  updateAlumno(request: IUpdateAlumnoCommand): Observable<IAlumnoViewModel> {
    return this.http.put<IAlumnoViewModel>(URL_ALUMNO_UPDATE, request).pipe(share());
  }
     
  deleteAlumno(id: number): Observable<IAlumnoViewModel> {
    return this.http.delete<IAlumnoViewModel>(`${URL_ALUMNO_DELETE}/${id}`).pipe(share());
  }
  
  getAlumnoById(id: number): Observable<IAlumnoViewModel> {
    return this.http.get<IAlumnoViewModel>(`${URL_ALUMNO_GET_BY_ID}/${id}`).pipe(share());
  }

  getAlumnoList(getAll: boolean, keyword: string): Observable<IAlumnoViewModel[]> {
    return this.http.get<IAlumnoViewModel[]>(`${URL_ALUMNO_GET_LIST}?getAll=${getAll}&keyword=${keyword}`).pipe(share());
  }
}