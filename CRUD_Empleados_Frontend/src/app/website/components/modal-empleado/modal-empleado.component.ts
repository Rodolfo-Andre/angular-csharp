import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Pais } from '../../../models/pais';
import { AreaTrabajo } from '../../../models/area-trabajo';
import { TipoDocumento } from '../../../models/tipo-documento';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  EmpleadoActualizar,
  EmpleadoObtener,
  EmpleadoRegistrar,
} from '../../../models/empleado';
import moment from 'moment';
import { EmpleadoService } from '../../../services/empleado.service';
import Swal, { SweetAlertIcon } from 'sweetalert2';

interface DialogData {
  listaPais: Pais[];
  listaAreaTrabajo: AreaTrabajo[];
  listaTipoDocumento: TipoDocumento[];
  empleado?: EmpleadoObtener;
}

@Component({
  selector: 'app-modal-empleado',
  templateUrl: './modal-empleado.component.html',
  styleUrl: './modal-empleado.component.css',
})
export class ModalEmpleadoComponent {
  formulario!: FormGroup;
  esEditar: boolean = false;

  constructor(
    private fb: FormBuilder,
    private empleadoService: EmpleadoService,
    public dialogRef: MatDialogRef<ModalEmpleadoComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogData
  ) {
    this.esEditar = Boolean(data.empleado);

    this.formulario = this.fb.group({
      nombres: [
        this.esEditar ? data.empleado?.nombres : '',
        [Validators.required],
      ],
      apellidos: [
        this.esEditar ? data.empleado?.apellidos : '',
        [Validators.required],
      ],
      correo: [
        this.esEditar ? data.empleado?.correo : '',
        [Validators.required, Validators.email],
      ],
      telefono: [
        this.esEditar ? data.empleado?.telefono : '',
        [Validators.required],
      ],
      fechaNacimiento: [
        this.esEditar
          ? moment(
              data.empleado?.fechaNacimiento,
              'MM/DD/YYYY HH:mm:ss'
            ).toDate()
          : '',
        [Validators.required],
      ],
      estadoCivil: [
        this.esEditar ? data.empleado?.estadoCivil : 0,
        [Validators.required, Validators.min(1)],
      ],
      idAreaTrabajo: [
        this.esEditar ? data.empleado?.idAreaTrabajo : 0,
        [Validators.required, Validators.min(1)],
      ],
      idPaisNacimiento: [
        this.esEditar ? data.empleado?.idPaisNacimiento : 0,
        [Validators.required, Validators.min(1)],
      ],
      idTipoDocumento: [
        this.esEditar ? data.empleado?.idTipoDocumento : 0,
        [Validators.required, Validators.min(1)],
      ],
      nroDocumento: [
        this.esEditar ? data.empleado?.nroDocumento : '',
        [Validators.required],
      ],
      sueldo: [
        this.esEditar ? data.empleado?.sueldo : 0,
        [Validators.required, Validators.min(1)],
      ],
      sexo: [
        this.esEditar ? data.empleado?.sexo : 0,
        [Validators.required, Validators.min(1)],
      ],
    });
  }

  cerrarModal(result: string = ''): void {
    this.dialogRef.close(result);
  }

  onSubmit() {
    if (this.formulario.valid) {
      if (this.esEditar) {
        this.actualizar();
        return;
      }

      this.registrar();
    }
  }

  registrar() {
    const empleado: EmpleadoRegistrar = {
      nombres: this.formulario.value.nombres,
      apellidos: this.formulario.value.apellidos,
      correo: this.formulario.value.correo,
      telefono: this.formulario.value.telefono,
      fechaNacimiento: moment(this.formulario.value.fechaNacimiento).format(
        'YYYY-MM-DD'
      ),
      estadoCivil: this.formulario.value.estadoCivil,
      idAreaTrabajo: this.formulario.value.idAreaTrabajo,
      idPaisNacimiento: this.formulario.value.idPaisNacimiento,
      idTipoDocumento: this.formulario.value.idTipoDocumento,
      nroDocumento: this.formulario.value.nroDocumento,
      sueldo: this.formulario.value.sueldo,
      sexo: this.formulario.value.sexo,
      codigoTelefono: '+51',
    };

    this.empleadoService.registrar(empleado).subscribe((datos) => {
      Swal.fire({
        title: datos.mensaje,
        icon: datos.tipoMensaje as SweetAlertIcon,
        target: 'body',
      });

      this.cerrarModal('exitoso');
    });
  }

  actualizar() {
    const empleado: EmpleadoActualizar = {
      idEmpleado: this.data.empleado?.id!,
      nombres: this.formulario.value.nombres,
      apellidos: this.formulario.value.apellidos,
      correo: this.formulario.value.correo,
      telefono: this.formulario.value.telefono,
      fechaNacimiento: moment(this.formulario.value.fechaNacimiento).format(
        'YYYY-MM-DD'
      ),
      estadoCivil: this.formulario.value.estadoCivil,
      idAreaTrabajo: this.formulario.value.idAreaTrabajo,
      idPaisNacimiento: this.formulario.value.idPaisNacimiento,
      idTipoDocumento: this.formulario.value.idTipoDocumento,
      nroDocumento: this.formulario.value.nroDocumento,
      sueldo: this.formulario.value.sueldo,
      sexo: this.formulario.value.sexo,
      codigoTelefono: '+51',
    };

    this.empleadoService.actualizar(empleado).subscribe((datos) => {
      Swal.fire({
        title: datos.mensaje,
        icon: datos.tipoMensaje as SweetAlertIcon,
        target: 'body',
      });

      this.cerrarModal('exitoso');
    });
  }
}
