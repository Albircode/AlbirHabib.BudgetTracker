import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Income } from 'src/app/shared/models/Income';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class IncomeService {

  constructor(private apiService : ApiService) { }
  createIncome(userIncome:Income, id:number):Observable<any>{

    return this.apiService.create(`${'/income/add'}`,userIncome);

  }



  updateIncome(income:Income, id:number):Observable<any>{

    return this.apiService.update(`${'/income/update/'}${id}`,income);

  }



  deleteIncomeById(id:number):Observable<{}>{

    return this.apiService.delete(`${'/income/delete/'}${id}`,id);

  }
}
