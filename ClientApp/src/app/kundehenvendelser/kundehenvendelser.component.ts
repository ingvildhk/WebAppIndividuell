import { Component, OnInit } from '@angular/core';
import { KundehenvendelserService } from './kundehenvendelser.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { Kundehenvendelse } from "./Kundehenvendelse";

@Component({
  selector: 'app-kundehenvendelser',
  templateUrl: './kundehenvendelser.component.html',
  styleUrls: ['./kundehenvendelser.component.css']
})
export class KundehenvendelserComponent implements OnInit {

    form: FormGroup;
    eKlikk: boolean;
    hKlikk: boolean;
    melding: string;

    constructor(private _service: KundehenvendelserService, private fb: FormBuilder) {
    }

    ngOnInit() {
        this.form = this.fb.group({
            henvendelse: [null, Validators.compose([Validators.required, Validators.pattern("[0-9a-zA-ZøæåØÆÅ\\-.\\?!@:,() ]{2,300}")])],
            epost: ['', [Validators.required, Validators.email]]
        });

        this.eKlikk = false;
        this.hKlikk = false;
    }

    async registrerHenvendelse() {
        var lagreHenvendelse = new Kundehenvendelse()
        lagreHenvendelse.epost = this.form.value.epost
        lagreHenvendelse.henvendelse = this.form.value.henvendelse

        this.form.setValue({
            epost: "",
            henvendelse: ""
        });
        this.form.markAsPristine();
        this.eKlikk = false;
        this.hKlikk = false;

        this.melding = await this._service.registrerHenvendelse(lagreHenvendelse)
        
    }
}
