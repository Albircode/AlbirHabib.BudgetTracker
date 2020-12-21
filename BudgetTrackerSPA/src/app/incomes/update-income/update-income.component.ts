import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user.service';
import { Income } from 'src/app/shared/models/Income';

@Component({
  selector: 'app-update-income',
  templateUrl: './update-income.component.html',
  styleUrls: ['./update-income.component.css']
})
export class UpdateIncomeComponent implements OnInit {

  incomeUpdate:Income={
    amount:0,
    description:'',
    date:'',
    remarks:''
  };

  userId:number;
  incomeId:number;
  invalidInput:boolean=false;

  constructor(private router: Router,
    private route: ActivatedRoute,
    private userService:UserService) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(
      p => {
        this.userId = +p.get('uid');
    });
    this.route.params.subscribe(p=>{this.incomeId = p['incomeId'] });
  }

  update(){
    this.userService.updateIncome(this.incomeUpdate, this.incomeId).subscribe((resp) =>
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
