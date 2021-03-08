import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FinancasComponent } from './financas/financas.component';
import { HttpClientModule } from '@angular/common/http';
import { FinancasService } from './financas/financas.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    FinancasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [FinancasService],
  bootstrap: [AppComponent]
})
export class AppModule { }
