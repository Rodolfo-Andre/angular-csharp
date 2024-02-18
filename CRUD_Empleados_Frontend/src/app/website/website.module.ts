import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../shared/shared.module';
import { InicioComponent } from './pages/inicio/inicio.component';
import { WebsiteRoutingModule } from './website-routing.module';
import { TablaEmpleadoComponent } from './components/tabla-empleado/tabla-empleado.component';
import { ModalEmpleadoComponent } from './components/modal-empleado/modal-empleado.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    InicioComponent,
    TablaEmpleadoComponent,
    ModalEmpleadoComponent,
  ],
  imports: [
    CommonModule,
    WebsiteRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class WebsiteModule {}
