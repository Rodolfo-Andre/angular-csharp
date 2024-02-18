interface EmpleadoGeneral {
  nombres: string;
  apellidos: string;
  codigoTelefono: string;
  telefono: string;
  correo: string;
  fechaNacimiento: string;
  sueldo: number;
  estadoCivil: string | number;
  idAreaTrabajo: number;
  idPaisNacimiento: number;
  idTipoDocumento: number;
  nroDocumento: string;
  sexo: 'M' | 'F' | number;
}

interface EmpleadoRegistrar extends EmpleadoGeneral {}

interface EmpleadoActualizar extends EmpleadoGeneral {
  idEmpleado: number;
}

interface EmpleadoObtener extends EmpleadoGeneral {
  id: number;
  areaTrabajo: number;
  paisNacimiento: number;
  tipoDocumento: number;
  estado: number;
}

interface EmpleadoEstado {
  idEmpleado: number;
  estado: number;
}

export {
  EmpleadoRegistrar,
  EmpleadoActualizar,
  EmpleadoObtener,
  EmpleadoEstado,
};
