import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import {
  EmpleadoActualizar,
  EmpleadoEstado,
  EmpleadoObtener,
  EmpleadoRegistrar,
} from '../models/empleado';
import { Respuesta } from '../models/respuesta';

@Injectable({
  providedIn: 'root',
})
export class EmpleadoService {
  private apiUrl = `${environment.API_URL}/api`;

  constructor(private http: HttpClient) {}

  obtenerLista(estado: number) {
    return this.http.get<EmpleadoObtener[]>(
      `${this.apiUrl}/empleado/${estado}`
    );
  }

  registrar(empleado: EmpleadoRegistrar) {
    return this.http.post<Respuesta>(`${this.apiUrl}/empleado`, empleado);
  }

  actualizar(empleado: EmpleadoActualizar) {
    return this.http.put<Respuesta>(`${this.apiUrl}/empleado`, empleado);
  }

  establecerEstado(empleado: EmpleadoEstado) {
    return this.http.patch<Respuesta>(`${this.apiUrl}/empleado`, empleado);
  }
}
