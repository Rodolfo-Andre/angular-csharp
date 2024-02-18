import { Component, OnInit } from '@angular/core';
import { PaisService } from '../../../services/pais.service';
import { AreaTrabajoService } from '../../../services/area-trabajo.service';
import { TipoDocumentoService } from '../../../services/tipo-documento.service';
import { EmpleadoService } from '../../../services/empleado.service';
import { MatTableDataSource } from '@angular/material/table';
import { EmpleadoEstado, EmpleadoObtener } from '../../../models/empleado';
import { MatDialog } from '@angular/material/dialog';
import { ModalEmpleadoComponent } from '../../components/modal-empleado/modal-empleado.component';
import { Pais } from '../../../models/pais';
import { AreaTrabajo } from '../../../models/area-trabajo';
import { TipoDocumento } from '../../../models/tipo-documento';
import Swal, { SweetAlertIcon } from 'sweetalert2';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrl: './inicio.component.css',
})
export class InicioComponent implements OnInit {
  dataSource = new MatTableDataSource<EmpleadoObtener>([]);
  estadoEmpleadoABuscar: string = '1';
  listaPais: Pais[] = [];
  listaAreaTrabajo: AreaTrabajo[] = [];
  listaTipoDocumento: TipoDocumento[] = [];

  constructor(
    private paisService: PaisService,
    private areaTrabajoService: AreaTrabajoService,
    private tipoDocumentoService: TipoDocumentoService,
    private empleadoService: EmpleadoService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.obtenerListaPais();
    this.obtenerListaAreaTrabajo();
    this.obtenerTipoDocumento();
    this.obtenerListaEmpleado();
  }

  obtenerListaEmpleado(estado: number = 1) {
    this.empleadoService.obtenerLista(estado).subscribe((datos) => {
      this.dataSource.data = datos;
    });
  }

  obtenerListaPais() {
    this.paisService.obtenerLista().subscribe((datos) => {
      this.listaPais = datos;
    });
  }

  obtenerListaAreaTrabajo() {
    this.areaTrabajoService.obtenerLista().subscribe((datos) => {
      this.listaAreaTrabajo = datos;
    });
  }

  obtenerTipoDocumento() {
    this.tipoDocumentoService.obtenerLista().subscribe((datos) => {
      this.listaTipoDocumento = datos;
    });
  }

  abrirModalDeEmpleadoRegistro(): void {
    const dialogRef = this.dialog.open(ModalEmpleadoComponent, {
      data: {
        listaPais: this.listaPais,
        listaAreaTrabajo: this.listaAreaTrabajo,
        listaTipoDocumento: this.listaTipoDocumento,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'exitoso') {
        this.obtenerListaEmpleado();
      }
    });
  }

  abrirModalDeEmpleadoActualizar(empleado: EmpleadoObtener): void {
    const dialogRef = this.dialog.open(ModalEmpleadoComponent, {
      data: {
        listaPais: this.listaPais,
        listaAreaTrabajo: this.listaAreaTrabajo,
        listaTipoDocumento: this.listaTipoDocumento,
        empleado: empleado,
      },
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result == 'exitoso') {
        this.obtenerListaEmpleado();
      }
    });
  }

  buscarEmpleados() {
    this.obtenerListaEmpleado(Number(this.estadoEmpleadoABuscar));
  }

  desactivarEmpleado(idEmpleado: number) {
    Swal.fire({
      title: `¿Estás seguro de desactivar el empleado con el id ${idEmpleado}?`,
      icon: 'question',
      target: 'body',
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'No',
    }).then((resultado) => {
      if (resultado.isConfirmed) {
        const empleadoEstado: EmpleadoEstado = {
          estado: 0,
          idEmpleado: idEmpleado,
        };

        this.empleadoService
          .establecerEstado(empleadoEstado)
          .subscribe((datos) => {
            Swal.fire({
              title: datos.mensaje,
              icon: datos.tipoMensaje as SweetAlertIcon,
              target: 'body',
            });

            this.buscarEmpleados();
          });
      }
    });
  }

  activarEmpleado(idEmpleado: number) {
    Swal.fire({
      title: `¿Estás seguro de activar el empleado con el id ${idEmpleado}?`,
      icon: 'question',
      target: 'body',
      showCancelButton: true,
      confirmButtonText: 'Sí',
      cancelButtonText: 'No',
    }).then((resultado) => {
      if (resultado.isConfirmed) {
        const empleadoEstado: EmpleadoEstado = {
          estado: 1,
          idEmpleado: idEmpleado,
        };

        this.empleadoService
          .establecerEstado(empleadoEstado)
          .subscribe((datos) => {
            Swal.fire({
              title: datos.mensaje,
              icon: datos.tipoMensaje as SweetAlertIcon,
              target: 'body',
            });

            this.buscarEmpleados();
          });
      }
    });
  }
}
