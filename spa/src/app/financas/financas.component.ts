import { Component, OnInit } from '@angular/core';
import { Meses } from './enums';
import { FinancasService } from './financas.service';

@Component({
  selector: 'app-financas',
  templateUrl: './financas.component.html',
  styleUrls: ['./financas.component.scss']
})
export class FinancasComponent implements OnInit {
  operacoes: any;
  receitas: any;
  despesas: any;
  mesSelecionado: any = 3;
  meses: any = Meses;

  constructor(private financasService: FinancasService) { }

  ngOnInit(): void {
    this.obterDados();
  }

  obterDados() {
    this.financasService.getOperacoes(this.mesSelecionado).subscribe((data: any) => {
      this.operacoes = data;
    })

    this.financasService.getDespesas(this.mesSelecionado).subscribe((data: any) => {
      this.despesas = data;
    })

    this.financasService.getReceitas(this.mesSelecionado).subscribe((data: any) => {
      this.receitas = data;
    })
  }

}