import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import {SignUpDetails} from '../models/signUpDetails';
import { environment } from '../../environments/environment';

@Injectable()
export class NewsLetterService {

    constructor(private http: HttpClient) { }


    SignUp(details: SignUpDetails): Observable<any> {
        return this.http.post<SignUpDetails>(`${environment.apiUrl}/NewsLetter/SignUp`, details);
    }
}
