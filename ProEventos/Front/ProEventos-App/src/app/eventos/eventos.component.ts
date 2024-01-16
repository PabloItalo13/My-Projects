import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  private _filtroLista: string = '';
  public eventos: any = [];
  public eventosFiltrados: any = [];
  larguraImagem: number = 150;
  margemImagem: number = 2;
  exibirImagem: boolean = true;

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string) : any {
    filtrarPor = filtrarPor.toLowerCase();
    return this.eventos.filter(
      (evento: any) => evento.tema.toLowerCase().indexOf(filtrarPor) !== -1 ||
                       evento.local.toLowerCase().indexOf(filtrarPor) !== -1
      // evento => evento.tema.toLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  alterarImagem() {
    this.exibirImagem = !this.exibirImagem;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = this.eventos
      },
      error => console.log(error)
    );
    // this.eventos = [
    //   {
    //     Tema: 'Angular',
    //     Local: 'Belo Horizonte'
    //   },
    //   {
    //     Tema: '.Net 5',
    //     Local: 'São Paulo'
    //   },
    //   {
    //     Tema: 'Angular e suas novidades',
    //     Local: 'Rio de Janeiro'
    //   }
    // ]
  }
}
