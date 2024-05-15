import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, share } from 'rxjs';
import { ICreateGradoCommand, IGradoViewModel, IUpdateGradoCommand } from '../shared/interfaces';
import { URL_GRADO_CREATE, URL_GRADO_DELETE, URL_GRADO_GET_BY_ID, URL_GRADO_GET_LIST, URL_GRADO_UPDATE } from '../shared/constants';

@Injectable({
  providedIn: 'root'
})
export class GradoService {
  http = inject(HttpClient);

  createGrado(request: ICreateGradoCommand): Observable<IGradoViewModel> {
    return this.http.post<IGradoViewModel>(URL_GRADO_CREATE, request).pipe(share());
  }

  updateGrado(request: IUpdateGradoCommand): Observable<IGradoViewModel> {
    return this.http.put<IGradoViewModel>(URL_GRADO_UPDATE, request).pipe(share());
  }
  
  deleteGrado(id: number): Observable<IGradoViewModel> {
    return this.http.delete<IGradoViewModel>(`${URL_GRADO_DELETE}/${id}`).pipe(share());
  }

  getGradoById(id: number): Observable<IGradoViewModel> {
    return this.http.get<IGradoViewModel>(`${URL_GRADO_GET_BY_ID}/${id}`).pipe(share());
  }

  getGradoList(getAll: boolean, keyword: string): Observable<IGradoViewModel[]> {
    return this.http.get<IGradoViewModel[]>(`${URL_GRADO_GET_LIST}?getAll=${getAll}&keyword=${keyword}`).pipe(share());
  }
}