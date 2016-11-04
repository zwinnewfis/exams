import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { Observable } from 'rxjs/Observable';
import { Configuration } from './app.constans';
import { Exam, UserExam } from './app.component';

@Injectable()
export class DataService {

    private actionUrl: string;
    private headersGet: Headers;
    private headersPost: Headers;

    constructor(private _http: Http, private _configuration: Configuration) {

        this.actionUrl = _configuration.ServerWithApiUrl + 'exams/';

        this.headersGet = new Headers();
        this.headersGet.append('Accept', 'application/json');

        this.headersPost = new Headers();
        this.headersPost.append('Content-Type', 'application/json');
        this.headersPost.append('Accept', 'application/json');
    }

    public GetAll = (): Promise<Exam[]> => {
        return this._http.get(this.actionUrl, { headers: this.headersGet })
            .toPromise()
            .then(response => response.json() as Exam[])
            .catch(this.handleError);
    }

    public GetSingle = (id: number): Promise<Exam> => {
        return this._http.get(this.actionUrl + id, { headers: this.headersGet })
            .toPromise()
            .then(response => response.json() as Exam)
            .catch(this.handleError);
    }

    public Check = (userExam: UserExam): Promise<string> => {
        let param = JSON.stringify(userExam);

        return this._http.post(this.actionUrl, param, { headers: this.headersPost })
            .toPromise()
            .then(response => response.json() as string)
            .catch(this.handleError);
    }

    private handleError(error: any): Promise<any> {
        return Promise.reject(error.message || error);
    }
}