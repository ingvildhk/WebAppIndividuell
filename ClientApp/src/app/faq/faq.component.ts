import { Component, OnInit, Input } from '@angular/core';
import { FaqService } from "./faq.service"

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.css']
})
export class FaqComponent implements OnInit {

  @Input() faq = []
  @Input() toggleState = {}
    @Input() enFaq;
    @Input() kategorier = []

  constructor(private _service: FaqService) { }

     async ngOnInit() {
         this.faq = await this._service.hentAlleFaq()
         this.kategorier = await this._service.hentKategorier()
         console.log(this.faq)
         console.log(this.kategorier)
    }

    async hentEnFaq(id: number) {

        //kopierer gammel toggle state, setter den man trykker på til true, andre til false
        const nyState = { ...this.toggleState }
        for (let key of Object.keys(nyState)) {
            nyState[key] = false;
        }
        nyState[id] = !this.toggleState[id]
        this.toggleState = nyState
        console.log(this.toggleState)
    }

    //legger til +1 i tommel opp når man trykker på den
    async tommelOpp(id: number) {
        this.enFaq = await this._service.hentEnFaq(id)
        this.enFaq.tommelOpp = this.enFaq.tommelOpp + 1
        this.enFaq = await this._service.endreEnFaq(id, this.enFaq)
        this.faq = await this._service.hentAlleFaq()
        console.log(this.enFaq)
    }

    //legger til +1 i tommel ned når man trykker på den
    async tommelNed(id: number) {
        this.enFaq = await this._service.hentEnFaq(id)
        this.enFaq.tommelNed = this.enFaq.tommelNed + 1
        this.enFaq = await this._service.endreEnFaq(id, this.enFaq)
        this.faq = await this._service.hentAlleFaq()
        console.log(this.enFaq)
    }
}
