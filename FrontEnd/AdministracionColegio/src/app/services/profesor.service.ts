import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, share } from 'rxjs';
import { ICreateProfesorCommand, IProfesorViewModel, IUpdateProfesorCommand } from '../shared/interfaces';
import { URL_PROFESOR_CREATE, URL_PROFESOR_DELETE, URL_PROFESOR_GET_BY_ID, URL_PROFESOR_GET_LIST, URL_PROFESOR_UPDATE } from '../shared/constants';

@Injectable({
  providedIn: 'root'
})
export class ProfesorService {
  http = inject(HttpClient);

  createProfesor(request: ICreateProfesorCommand): Observable<IProfesorViewModel> {
    return this.http.post<IProfesorViewModel>(URL_PROFESOR_CREATE, request).pipe(share());
  }

  updateProfesor(request: IUpdateProfesorCommand): Observable<IProfesorViewModel> {
    return this.http.put<IProfesorViewModel>(URL_PROFESOR_UPDATE, request).pipe(share());
  }

  deleteProfesor(id: number): Observable<IProfesorViewModel> {
    return this.http.delete<IProfesorViewModel>(`${URL_PROFESOR_DELETE}/${id}`).pipe(share());
  }

  getProfesorById(id: number): Observable<IProfesorViewModel> {
    return this.http.get<IProfesorViewModel>(`${URL_PROFESOR_GET_BY_ID}/${id}`).pipe(share());
  }
  
  getProfesorList(getAll: boolean, keyword: string): Observable<IProfesorViewModel[]> {
    return this.http.get<IProfesorViewModel[]>(`${URL_PROFESOR_GET_LIST}?getAll=${getAll}&keyword=${keyword}`).pipe(share());
  }
}
