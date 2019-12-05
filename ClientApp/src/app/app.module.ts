import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FaqComponent } from './faq/faq.component';
import { KundehenvendelserComponent } from './kundehenvendelser/kundehenvendelser.component';

import { FaqService } from "./faq/faq.service";
import { KundehenvendelserService } from './kundehenvendelser/kundehenvendelser.service';
import { FooterComponent } from './footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FaqComponent,
    KundehenvendelserComponent,
    FooterComponent,
    ],

  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ],
    providers: [FaqService, KundehenvendelserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
