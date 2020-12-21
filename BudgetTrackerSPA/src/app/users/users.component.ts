import { Component, OnInit } from '@angular/core';
import { UserService } from '../core/services/user.service';
import { User } from '../shared/models/User';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users:User[];
  constructor(private userService:UserService) { }

  ngOnInit(): void {
  this.getData();
  }
  getData():void{

    this.userService.getAllUsers().subscribe(

      (user)=>{ this.users = user; });

  }
  deleteUser(id:number){

    this.userService.deleteUserById(id).subscribe(

      succ => {

        this.getData();

    });
  }

}
