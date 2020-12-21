import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';

@Component({
  selector: 'app-user-update',
  templateUrl: './user-update.component.html',
  styleUrls: ['./user-update.component.css']
})
export class UserUpdateComponent implements OnInit {

  




  userUpdate:UserUpdate={

    email:'',

    password:'',

    fullName:''

  };



  userId:number;

  invalidInput:boolean=false;





  constructor(private router: Router,

    private route: ActivatedRoute,

    private userService:UserService

    ) { }



  ngOnInit(): void {

    this.route.paramMap.subscribe(

      p => {

        this.userId = +p.get('id');

    });

  }





  update(){

    this.userService.updateUser(this.userUpdate, this.userId).subscribe((resp) =>

    {

      if (resp) {

        this.invalidInput = false;

        this.router.navigate([`${'Users/'}${this.userId}`]);

      }



    },

    (err: any) => {

      this.invalidInput = true;

    }

    );

  }

}
