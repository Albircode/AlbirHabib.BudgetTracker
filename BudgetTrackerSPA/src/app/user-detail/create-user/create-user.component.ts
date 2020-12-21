import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { User } from 'src/app/shared/models/User';

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {

  userCreate:User={ email:'', password:'', fullName:''

  };





  returnUrl:string;

  invalidInput:boolean=false;



  constructor(    

    private router: Router,

    private route: ActivatedRoute,

    private userService:UserService) {}



  ngOnInit(): void {

    this.route.queryParams.subscribe(

      (params) => (this.returnUrl = params.returnUrl || '/')

    );

  }



  create(){

    this.userService.createUser(this.userCreate).subscribe((resp) =>

    {

      if (resp) {

        this.invalidInput = false;

        this.router.navigate([this.returnUrl]);

      }

    },

    (err: any) => {

      this.invalidInput = true;

    }

    );

  }



}
