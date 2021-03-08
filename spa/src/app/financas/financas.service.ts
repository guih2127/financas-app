import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()
export class FinancasService {
    apiUrl: string = 'https://localhost:5001/api/';

    constructor(private http: HttpClient) { }

    getOperacoes(mes: number) {
        return this.http.get(this.apiUrl + 'operacoes?mes=' + mes);
    }

    getReceitas(mes: number) {
        return this.http.get(this.apiUrl + 'operacoes/receitas?mes=' + mes);
    }

    getDespesas(mes: number) {
        return this.http.get(this.apiUrl + 'operacoes/despesas?mes=' + mes);
    }
}