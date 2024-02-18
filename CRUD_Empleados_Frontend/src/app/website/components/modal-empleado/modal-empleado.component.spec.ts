import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalEmpleadoComponent } from './modal-empleado.component';

describe('ModalEmpleadoRegistrarComponent', () => {
  let component: ModalEmpleadoComponent;
  let fixture: ComponentFixture<ModalEmpleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ModalEmpleadoComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ModalEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
