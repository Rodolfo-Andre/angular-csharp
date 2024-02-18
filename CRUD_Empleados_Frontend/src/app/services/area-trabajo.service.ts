import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { AreaTrabajo } from '../models/area-trabajo';

@Injectable({
  providedIn: 'root',
})
export class AreaTrabajoService {
  private apiUrl = `${environment.API_URL}/api`;

  constructor(private http: HttpClient) {}

  obtenerLista() {
    return this.http.get<AreaTrabajo[]>(`${this.apiUrl}/areatrabajo`);
  }
}
