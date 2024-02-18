import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Pais } from '../models/pais';

@Injectable({
  providedIn: 'root',
})
export class PaisService {
  private apiUrl = `${environment.API_URL}/api`;

  constructor(private http: HttpClient) {}

  obtenerLista() {
    return this.http.get<Pais[]>(`${this.apiUrl}/pais`);
  }
}
