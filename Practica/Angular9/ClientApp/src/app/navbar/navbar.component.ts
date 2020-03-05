import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styles: []
})
export class NavbarComponent implements OnInit {

  constructor() { }

  public appName = 'Estadistica de Alumnos';

  ngOnInit(): void {
  }

}
