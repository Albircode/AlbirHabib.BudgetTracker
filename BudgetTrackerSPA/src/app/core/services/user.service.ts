import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from 'src/app/shared/models/User';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private apiService : ApiService) { }
  getAllUsers():Observable<User[]>{

    return this.apiService.getAll('User');

  }

  getUserDetailsById(id:number):Observable<User>{

    return this.apiService.getOne('User', id);

  }

  deleteUserById(id:number):Observable<{}>{

    return this.apiService.delete('User/delete',id);

  }



  createUser(userCreate:User):Observable<any>{

    return this.apiService.create('Users/register',userCreate);

  }



  updateUser(userUpdate:User, id:number):Observable<any>{

    return this.apiService.update(`${'Users/'}${id}${'/update'}`,userUpdate);

  }
}
