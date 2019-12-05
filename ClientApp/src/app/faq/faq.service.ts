import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators'


@Injectable()
export class FaqService {

    constructor(private _http: HttpClient) { }

    hentAlleFaq(): Promise<any[]> {
        return this._http.get("api/faq/")
            .pipe(first())
            .toPromise() as Promise<any>
    }

    hentKategorier(): Promise<any[]> {
        return this._http.get("api/kategori/")
            .pipe(first())
            .toPromise() as Promise<any>
    }

    hentEnFaq(id: number): Promise<any> {
        return this._http.get("api/faq/" + id)
            .pipe(first())
            .toPromise()
    }

    endreEnFaq(id: number, enFaq: any): Promise<any>  {
        return this._http.put("api/faq/" + id, enFaq)
            .pipe(first())
            .toPromise();
    }
}


    
