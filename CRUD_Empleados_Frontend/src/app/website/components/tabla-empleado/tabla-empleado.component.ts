import {
  AfterViewInit,
  Component,
  EventEmitter,
  Injectable,
  Input,
  Output,
  ViewChild,
} from '@angular/core';
import { MatPaginator, MatPaginatorIntl } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { EmpleadoObtener } from '../../../models/empleado';

@Injectable()
class CustomMatPaginatorIntl extends MatPaginatorIntl {
  override itemsPerPageLabel = 'Elementos por página';
  override nextPageLabel = 'Página siguiente';
  override previousPageLabel = 'Página anterior';
  override firstPageLabel = 'Primera página';
  override lastPageLabel = 'Última página';
}

@Component({
  selector: 'app-tabla-empleado',
  templateUrl: './tabla-empleado.component.html',
  styleUrl: './tabla-empleado.component.css',
  providers: [{ provide: MatPaginatorIntl, useClass: CustomMatPaginatorIntl }],
})
export class TablaEmpleadoComponent implements AfterViewInit {
  displayedColumns: string[] = [
    'idEmpleado',
    'nombreCompleto',
    'telefonoCompleto',
    'correo',
    'fechaNacimiento',
    'areaTrabajo',
    'acciones',
  ];
  @Input()
  dataSource = new MatTableDataSource<EmpleadoObtener>([]);

  @Output() desactivarEmpleado: EventEmitter<number> = new EventEmitter();
  @Output() activarEmpleado: EventEmitter<number> = new EventEmitter();
  @Output() abrirModalDeEmpleadoActualizar: EventEmitter<EmpleadoObtener> =
    new EventEmitter();

  constructor() {}

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  emitirDesactivarEmpleado(idEmpleado: number) {
    this.desactivarEmpleado.emit(idEmpleado);
  }

  emitirActivarEmpleado(idEmpleado: number) {
    this.activarEmpleado.emit(idEmpleado);
  }

  emitirAbrirModalDeEmpleadoActualizar(empleado: EmpleadoObtener) {
    this.abrirModalDeEmpleadoActualizar.emit(empleado);
  }
}
