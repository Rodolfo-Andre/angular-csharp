import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { TipoDocumento } from '../models/tipo-documento';

@Injectable({
  providedIn: 'root',
})
export class TipoDocumentoService {
  private apiUrl = `${environment.API_URL}/api`;

  constructor(private http: HttpClient) {}

  obtenerLista() {
    return this.http.get<TipoDocumento[]>(`${this.apiUrl}/tipodocumento`);
  }
}
