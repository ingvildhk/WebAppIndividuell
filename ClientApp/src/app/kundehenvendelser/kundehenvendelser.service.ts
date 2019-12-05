import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { first } from 'rxjs/operators'


@Injectable()
export class KundehenvendelserService {

    constructor(private _http: HttpClient) { }

    registrerHenvendelse(lagreHenvendelse): Promise<any> {

        return this._http.post("api/kundehenvendelse", lagreHenvendelse)
            .pipe(first()).toPromise() as Promise<any>;
    }

    /*
     this._http.post("api/kundehenvendelse", lagreHenvendelse)
    .subscribe(
        retur => {
            true;
        },
        error => alert(error),
            () => console.log("ferdig post-api/kundehenvendelse")
            );
     */
}
