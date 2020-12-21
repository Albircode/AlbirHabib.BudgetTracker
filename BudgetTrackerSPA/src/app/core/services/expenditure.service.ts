import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Expenditure } from 'src/app/shared/models/Expenditure';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ExpenditureService {

  constructor(private apiService : ApiService) { }
  createExp(userExp:Expenditure, id:number):Observable<any>{

    return this.apiService.create(`${'/expendture/add'}`,userExp);

  }



  updateExp(exp:Expenditure, id:number):Observable<any>{

    return this.apiService.update(`${'Expendture/update/'}${id}`,exp);

  }



  deleteExpenditureById(id:number):Observable<{}>{

    return this.apiService.delete(`${'Expendture/delete/'}${id}`,id);

  }
}
