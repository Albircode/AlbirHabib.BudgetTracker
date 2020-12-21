import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders, HttpParams  } from "@angular/common/http";
import { environment } from 'src/environments/environment';

import {map} from 'rxjs/operators';

import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(protected http:HttpClient) { }
  getAll(path: string, id?:number): Observable<any[]>{

    if(id)

    {
      return this.http.get(`${environment.apiUrl}${path}` +`/` +id).pipe(map(resp=>resp as any[]));
    }

    else{
      return this.http.get(`${environment.apiUrl}${path}`).pipe(map(resp=>resp as any[]));
    }

  }
  getOne(path:string, id?:number): Observable<any> {

    let getUrl: string;

    

    if (id){

      getUrl = `${environment.apiUrl}${path}` + '/' + id;

    }

    else{

      getUrl = `${environment.apiUrl}${path}`;

    }



    return this.http

    .get(getUrl)

    .pipe(map((resp) => resp as any));

  }



  create(path:string, resource:any):Observable<any>{

    return this.http.post(`${environment.apiUrl}${path}`,resource).pipe(map((resp)=>resp));

  }



  update(path: string, resource:any):Observable<any> {

    return this.http.put(`${environment.apiUrl}${path}`,resource).pipe(map((resp)=>resp));

  }



  delete(path: string, id:number):Observable<{}>{

    return this.http.delete(`${environment.apiUrl}${path}` + '/' + id).pipe(

      map(response => response)

    );

  }

  }
